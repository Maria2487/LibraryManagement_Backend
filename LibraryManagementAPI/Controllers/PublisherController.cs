using LibraryManagement.Application.DTOs.Publisher;
using LibraryManagement.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublisherController : ControllerBase
    {
        private readonly IPublisherService publisherService;

        public PublisherController(IPublisherService publisherService)
        {
            this.publisherService = publisherService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var publisher = await publisherService.GetAll();

            return Ok(publisher);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var publisher = await publisherService.GetById(id);

            return Ok(publisher);
        }

        [HttpPost]
        public async Task<IActionResult> Create(PublisherDto publisherDto)
        {
            var publisher = await publisherService.Create(publisherDto);

            return Ok(publisher);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, PublisherDto publisherDto)
        {
            var publisher = await publisherService.Update(id, publisherDto);

            return Ok(publisher);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await publisherService.Delete(id);

            return Ok();
        }
    }
}
