using LibraryManagement.Application.DTOs.Loan;
using LibraryManagement.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoanController : ControllerBase
    {
        private readonly ILoanService loanService;

        public LoanController(ILoanService loanService)
        {
            this.loanService = loanService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var loan = await loanService.GetAll();

            return Ok(loan);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var loan = await loanService.GetById(id);

            return Ok(loan);
        }

        [HttpPost]
        public async Task<IActionResult> Create(LoanDto loanDto)
        {
            var loan = await loanService.Create(loanDto);

            return Ok(loan);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, LoanDto loanDto)
        {
            var loan = await loanService.Update(id, loanDto);

            return Ok(loan);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await loanService.Delete(id);

            return Ok();
        }

        [HttpGet("get-active-loans/{membershipId}")]
        public async Task<IActionResult> GetActiveLoans(Guid membershipId)
        {
            var loans = await loanService.GetActiveLoans(membershipId);

            return Ok(loans);
        }

        [HttpPut("return-book/{loanId}")]
        public async Task<IActionResult> ReturnBook(Guid loanId)
        {
            var loan = await loanService.ReturnBook(loanId);
             
            return Ok(loan);
        }

        [HttpGet("passed-due-date/{membershipId}")]
        public async Task<IActionResult> GetPassedDueDate(Guid membershipId)
        {
            var loans = await loanService.GetPassedDueDate(membershipId);

            return Ok(loans);
        }
    }
}
