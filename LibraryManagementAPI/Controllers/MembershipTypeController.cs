using LibraryManagement.Application.DTOs.MembershipType;
using LibraryManagement.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MembershipTypeController : ControllerBase
    {
        private readonly IMembershipTypeService membershipTypeService;

        public MembershipTypeController(IMembershipTypeService membershipTypeService)
        {
            this.membershipTypeService = membershipTypeService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var membershipType = await membershipTypeService.GetAll();

            return Ok(membershipType);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var membershipType = await membershipTypeService.GetById(id);

            return Ok(membershipType);
        }

        [HttpPost]
        public async Task<IActionResult> Create(MembershipTypeDto membershipTypeDto)
        {
            var membershipType = await membershipTypeService.Create(membershipTypeDto);

            return Ok(membershipType);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, MembershipTypeDto membershipTypeDto)
        {
            var membershipType = await membershipTypeService.Update(id, membershipTypeDto);

            return Ok(membershipType);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await membershipTypeService.Delete(id);

            return Ok();
        }
    }
}
