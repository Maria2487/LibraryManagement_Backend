using LibraryManagement.Application.DTOs.Genre;

namespace LibraryManagement.Application.Services.Interfaces
{
    public interface IGenreService
    {
        Task<ResponseGenreDto> Create(GenreDto genreDto);
        Task<ResponseGenreDto> GetById(int id);
        Task<List<ResponseGenreDto>> GetAll();
        Task<ResponseGenreDto> Update(int id, GenreDto genreDto);
        Task Delete(int id);
    }
}
