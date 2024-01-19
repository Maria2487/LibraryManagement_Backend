using LibraryManagement.Application.DTOs.Author;

namespace LibraryManagement.Application.Services.Interfaces
{
    public interface IAuthorService
    {
        Task<ResponseAuthorDto> Create(AuthorDto author);
        Task<ResponseAuthorDto> GetById(Guid id);
        Task<List<ResponseAuthorDto>> GetAll();
        Task<ResponseAuthorDto> Update(Guid id, AuthorDto author);
        Task Delete(Guid id);
    }
}
