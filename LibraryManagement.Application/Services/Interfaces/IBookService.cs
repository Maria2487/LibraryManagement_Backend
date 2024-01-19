using LibraryManagement.Application.DTOs.Book;
using LibraryManagement.Domain.Filters;

namespace LibraryManagement.Application.Services.Interfaces
{
    public interface IBookService
    {
        Task<ResponseBookDto> Create(BookDto bookDto);
        Task<ResponseBookDto> GetById(Guid id);
        Task<List<ResponseBookDto>> GetAll(BookFilter bookFilter);
        Task<ResponseBookDto> Update(Guid id, BookDto bookDto);
        Task Delete(Guid id);
    }
}
