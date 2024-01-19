using AutoMapper;
using LibraryManagement.Application.DTOs.Author;
using LibraryManagement.Application.DTOs.Genre;
using LibraryManagement.Application.Services.Interfaces;
using LibraryManagement.Domain.Entities.EnumEntities;
using LibraryManagement.Domain.Entities.RegularEntities;
using LibraryManagement.Infrastructure.Repositories.Interfaces;

namespace LibraryManagement.Application.Services
{
    public class GenreService : IGenreService
    {
        private readonly IGenreRepository genreRepository;
        private readonly IMapper mapper;

        public GenreService(IGenreRepository genreRepository, IMapper mapper)
        {
            this.genreRepository = genreRepository;
            this.mapper = mapper;
        }

        public async Task<ResponseGenreDto> Create(GenreDto genreDto)
        {
            var entity = mapper.Map<Genre>(genreDto);
            var genre = await genreRepository.Create(entity);

            return mapper.Map<ResponseGenreDto>(genre);
        }

        public async Task Delete(int id)
        {
            var genre = await genreRepository.GetById(id);

            if (genre is null)
            {
                throw new KeyNotFoundException();
            }

            await genreRepository.Delete(genre);
        }

        public async Task<List<ResponseGenreDto>> GetAll()
        {
            var genres = await genreRepository.GetAll();

            return mapper.Map<List<ResponseGenreDto>>(genres);
        }

        public async Task<ResponseGenreDto> GetById(int id)
        {
            var genre = await genreRepository.GetById(id);

            if (genre is null)
            {
                throw new KeyNotFoundException();
            }

            return mapper.Map<ResponseGenreDto>(genre);
        }

        public async Task<ResponseGenreDto> Update(int id, GenreDto genreDto)
        {
            var genre = await genreRepository.GetById(id);

            if (genre is null)
            {
                throw new KeyNotFoundException();
            }

            mapper.Map(genreDto, genre);
            await genreRepository.Update(genre);

            return mapper.Map<ResponseGenreDto>(genre);
        }
    }
}
