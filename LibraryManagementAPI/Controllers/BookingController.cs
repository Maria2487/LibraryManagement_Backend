using LibraryManagement.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookingService bookingService;

        public BookingController(IBookingService bookingService)
        {
            this.bookingService = bookingService;
        }

        // de terminat
        [HttpPost]
        public IActionResult Post(string email, Guid bookId)
        {
            var response = bookingService.Create(email, bookId);

            return Ok(response);
        }
    }
}
