using AutoMapper;
using LibraryManagement.Application.DTOs.Author;
using LibraryManagement.Application.Services.Interfaces;
using LibraryManagement.Domain.Entities.RegularEntities;
using LibraryManagement.Infrastructure.Repositories.Interfaces;

namespace LibraryManagement.Application.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly IAuthorRepository authorRepository;
        private readonly IMapper mapper;

        public AuthorService(IAuthorRepository authorRepository, IMapper mapper)
        {
            this.authorRepository = authorRepository;
            this.mapper = mapper;
        }

        public async Task<ResponseAuthorDto> Create(AuthorDto authorDto)
        {
            var entity = mapper.Map<Author>(authorDto);
            var author = await authorRepository.Create(entity);

            return mapper.Map<ResponseAuthorDto>(author);
        }

        public async Task Delete(Guid id)
        {
            var author = await authorRepository.GetById(id);

            if (author is null)
            {
                throw new KeyNotFoundException();
            }

            await authorRepository.Delete(author);
        }

        public async Task<List<ResponseAuthorDto>> GetAll()
        {
            var authors = await authorRepository.GetAll();

            return mapper.Map<List<ResponseAuthorDto>>(authors);
        }

        public async Task<ResponseAuthorDto> GetById(Guid id)
        {
            var author = await authorRepository.GetById(id);

            if (author is null)
            {
                throw new KeyNotFoundException();
            }

            return mapper.Map<ResponseAuthorDto>(author);
        }

        public async Task<ResponseAuthorDto> Update(Guid id, AuthorDto authorDto)
        {
            var author = await authorRepository.GetById(id);

            if (author is null)
            {
                throw new KeyNotFoundException();
            }

            mapper.Map(authorDto, author);
            await authorRepository.Update(author);

            return mapper.Map<ResponseAuthorDto>(author);
        }
    }
}
