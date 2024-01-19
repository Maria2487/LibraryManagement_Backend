using LibraryManagement.Application.DTOs.Book;
using LibraryManagement.Application.Services.Interfaces;
using LibraryManagement.Domain.Filters;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LibraryManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookService bookService;

        public BookController(IBookService bookService)
        {
            this.bookService = bookService;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery]BookFilter filter)
        {
            var books = await bookService.GetAll(filter);

            return Ok(books);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var book = await bookService.GetById(id);

            return Ok(book);
        }

        [HttpPost]
        public async Task<IActionResult> Create(BookDto bookDto)
        {
            var book = await bookService.Create(bookDto);

            return Ok(book);
        }

        // PUT api/<BookController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, BookDto bookDto)
        {
            var book = await bookService.Update(id, bookDto);

            return Ok(book);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await bookService.Delete(id);

            return Ok();
        }
    }
}
