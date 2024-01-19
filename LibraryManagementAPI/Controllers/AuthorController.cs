using LibraryManagement.Application.DTOs.Author;
using LibraryManagement.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorService authorService;

        public AuthorController(IAuthorService authorService)
        {
            this.authorService = authorService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var authors = await authorService.GetAll();

            return Ok(authors);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var author = await authorService.GetById(id);

            return Ok(author);
        }

        [HttpPost]
        public async Task<IActionResult> Create(AuthorDto authorDto)
        {
            var author = await authorService.Create(authorDto);

            return Ok(author);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, AuthorDto authorDto)
        {
            var author = await authorService.Update(id, authorDto);

            return Ok(author);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await authorService.Delete(id);

            return Ok();
        }
    }
}
