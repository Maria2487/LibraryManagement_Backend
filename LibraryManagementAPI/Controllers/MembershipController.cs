using LibraryManagement.Application.DTOs.Membership;
using LibraryManagement.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MembershipController : ControllerBase
    {
        private readonly IMembershipService membershipService;

        public MembershipController(IMembershipService membershipService)
        {
            this.membershipService = membershipService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var membership = await membershipService.GetAll();

            return Ok(membership);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var membership = await membershipService.GetById(id);

            return Ok(membership);
        }

        [HttpPost]
        public async Task<IActionResult> Create(MembershipDto membershipDto)
        {
            var membership = await membershipService.Create(membershipDto);

            return Ok(membership);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, MembershipDto membershipDto)
        {
            var membership = await membershipService.Update(id, membershipDto);

            return Ok(membership);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await membershipService.Delete(id);

            return Ok();
        }

        [HttpGet("verify-status")]
        public async Task<IActionResult> VerifyMembershipStatus(Guid membershipId)
        {
            var membership = await membershipService.GetById(membershipId);

            if (membership is null)
            {
                return NotFound();
            }

            return DateTime.UtcNow > membership.EndDate ? Ok("Membership expired") : Ok("Membership is valid");
        }
    }
}
