using LibraryManagement.Application.DTOs.Genre;
using LibraryManagement.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenreController : ControllerBase
    {
        private readonly IGenreService genreService;

        public GenreController(IGenreService genreService)
        {
            this.genreService = genreService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var genres = await genreService.GetAll();

            return Ok(genres);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var genre = await genreService.GetById(id);

            return Ok(genre);
        }

        [HttpPost]
        public async Task<IActionResult> Create(GenreDto genreDto)
        {
            var genre = await genreService.Create(genreDto);

            return Ok(genre);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, GenreDto genreDto)
        {
            var genre = await genreService.Update(id, genreDto);

            return Ok(genre);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await genreService.Delete(id);

            return Ok();
        }
    }
}
