using AutoMapper;
using LibraryManagement.Application.DTOs.Book;
using LibraryManagement.Application.Services.Interfaces;
using LibraryManagement.Domain.Entities.RegularEntities;
using LibraryManagement.Domain.Filters;
using LibraryManagement.Infrastructure.Caching;
using LibraryManagement.Infrastructure.Repositories.Interfaces;

namespace LibraryManagement.Application.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository bookRepository;
        private readonly IMapper mapper;
        private readonly IAzureStorageService storageService;
        private readonly IAuthorRepository authorRepository;
        private readonly IGenreRepository genreRepository;
        private readonly IPublisherRepository publisherRepository;
        private readonly ICache chacheManager;

        public BookService(IBookRepository bookRepository, IMapper mapper, 
            IAzureStorageService storageService, ICache chacheService)
        {
            this.bookRepository = bookRepository;
            this.mapper = mapper;
            this.storageService = storageService;
            this.chacheManager = chacheService;
        }

        public async Task<ResponseBookDto> Create(BookDto bookDto)
        {
            var entity = mapper.Map<Book>(bookDto);

            entity.CoverPhoto = string.Empty;

            await bookRepository.Create(entity);
            var book = await bookRepository.GetById(entity.Id);

            chacheManager.Clear();

            return mapper.Map<ResponseBookDto>(book);
        }

        public async Task Delete(Guid id)
        {
            var book = await bookRepository.GetById(id);

            if (book is null)
            {
                throw new KeyNotFoundException();
            }

            string key = $"{nameof(Book)}_{id}";

            if (chacheManager.IsSet(key))
            {
                chacheManager.Remove(key);
            }

            await bookRepository.Delete(book);
        }

        public async Task<List<ResponseBookDto>> GetAll(BookFilter bookFilter)
        {
            List<Book> books;

            if (chacheManager.IsEmpty())
            {
                books = await bookRepository.GetFiltered(bookFilter);

                foreach (var item in books)
                {
                    chacheManager.Set($"{nameof(Book)}_{item.Id}", item);
                }
            }
            else
            {
                books = chacheManager.GetAll<Book>();
                books = books.AsQueryable().Where(bookFilter.GetQuery()).ToList();
                books = bookFilter.FilterByGenres(books);
                books = bookFilter.FilterByAuthors(books);
            }

            return mapper.Map<List<ResponseBookDto>>(books);
        }

        public async Task<ResponseBookDto> GetById(Guid id)
        {
            string key = $"{nameof(Book)}_{id}";

            Book book;

            if (chacheManager.IsSet(key))
            {
                book = chacheManager.Get<Book>(key);
            }
            else
            {
                book = await bookRepository.GetById(id);
                chacheManager.Set(key, book);
            }

            if (book is null)
            {
                throw new KeyNotFoundException();
            }

            return mapper.Map<ResponseBookDto>(book);
        }

        public async Task<ResponseBookDto> Update(Guid id, BookDto bookDto)
        {
            var book = await bookRepository.GetById(id);

            if (book is null)
            {
                throw new KeyNotFoundException();
            }

            mapper.Map(bookDto, book);
            await bookRepository.Update(book);

            string key = $"{nameof(Book)}_{id}";

            if (!chacheManager.IsSet(key))
            {
                chacheManager.Set(key, book);
            }
            else
            {
                chacheManager.Remove(key);
                chacheManager.Set(key, book);
            }

            return mapper.Map<ResponseBookDto>(book);
        }
    }
}
