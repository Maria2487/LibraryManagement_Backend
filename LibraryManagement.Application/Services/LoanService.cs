using AutoMapper;
using LibraryManagement.Application.DTOs.Loan;
using LibraryManagement.Application.Services.Interfaces;
using LibraryManagement.Domain.Entities.RegularEntities;
using LibraryManagement.Infrastructure.Repositories.Interfaces;

namespace LibraryManagement.Application.Services
{
    public class LoanService : ILoanService
    {
        public readonly IMembershipRepository membershipRepository;
        public readonly IMembershipTypeRepository membershipTypeRepository;
        public readonly IBookRepository bookRepository;
        public readonly ILoanRepository loanRepository;
        public readonly IMapper mapper;

        public LoanService(ILoanRepository loanRepository, IMapper mapper,
            IMembershipRepository membershipRepository, IBookRepository bookRepository, 
            IMembershipTypeRepository membershipTypeRepository)
        {
            this.loanRepository = loanRepository;
            this.mapper = mapper;
            this.membershipRepository = membershipRepository;
            this.bookRepository = bookRepository;
            this.membershipTypeRepository = membershipTypeRepository;
        }

        public async Task<ResponseLoanDto> Create(LoanDto loanDto)
        {
            var membership = await membershipRepository.GetById(loanDto.MembershipId);

            if (DateTime.UtcNow > membership.EndDate)
            {
                return null;
            }

            var activeLoans = await loanRepository.GetActiveLoans(membership.Id);

            if (activeLoans.Count == membership.MembershipType.NumberOfLoansAllowed)
            {
                return null;
            }

            var bookToLoan = await bookRepository.GetById(loanDto.BookId);

            if (bookToLoan == null || bookToLoan.Status != Domain.Enums.BookStatus.Available)
            {
                return null;
            }

            var entity = mapper.Map<Loan>(loanDto);
            entity.Status = Domain.Enums.LoanStatus.Active;
            var loan = await loanRepository.Create(entity);

            if (loan is not null)
            {
                bookToLoan.Status = Domain.Enums.BookStatus.OnLoan;
                await bookRepository.Update(bookToLoan);
            }

            return mapper.Map<ResponseLoanDto>(loan);
        }

        public async Task Delete(Guid id)
        {
            var loan = await loanRepository.GetById(id);

            if (loan is null)
            {
                throw new KeyNotFoundException();
            }

            await loanRepository.Delete(loan);
        }

        public async Task<List<ResponseLoanDto>> GetAll()
        {
            var loans = await loanRepository.GetAll();

            return mapper.Map<List<ResponseLoanDto>>(loans);
        }

        public async Task<ResponseLoanDto> GetById(Guid id)
        {
            var loan = await loanRepository.GetById(id);

            if (loan is null)
            {
                throw new KeyNotFoundException();
            }

            return mapper.Map<ResponseLoanDto>(loan);
        }

        public async Task<ResponseLoanDto> Update(Guid id, LoanDto loanDto)
        {
            var book = await loanRepository.GetById(id);

            if (book is null)
            {
                throw new KeyNotFoundException();
            }

            mapper.Map(loanDto, book);
            await loanRepository.Update(book);

            return mapper.Map<ResponseLoanDto>(book);
        }

        public async Task<ResponseLoanDto> ReturnBook(Guid id)
        {
            var loan = await loanRepository.GetById(id);

            if (loan is null)
            {
                throw new KeyNotFoundException();
            }

            // Update loan status
            loan.Status = Domain.Enums.LoanStatus.Returned;
            loan.ReturnDate = DateTime.UtcNow;
            await loanRepository.Update(loan);

            // Update availability of returned book
            var book = await bookRepository.GetById(loan.BookId);
            book.Status = Domain.Enums.BookStatus.Available;
            await bookRepository.Update(book);

            // Verify for membership type upgrade
            var membership = await membershipRepository.GetById(loan.MembershipId);
            var numberOfLoans = await loanRepository.GetNumberOfReturnedLoans(loan.MembershipId);
            var membershipTypes = await membershipTypeRepository.GetAll();
            var newType = membershipTypes.LastOrDefault(m => numberOfLoans >= m.NumberOfLoansNeeded);

            if (newType.Id != membership.MembershipTypeId)
            {
                membership.MembershipTypeId = newType.Id;
                await membershipRepository.Update(membership);
            }

            return mapper.Map<ResponseLoanDto>(loan);
        }

        public async Task<List<ResponseLoanDto>> GetActiveLoans(Guid membershipId)
        {
            var activeLoans = await loanRepository.GetActiveLoans(membershipId);

            return mapper.Map<List<ResponseLoanDto>>(activeLoans);
        }

        public async Task<List<ResponseBookLoanDto>> GetPassedDueDate(Guid membershipId)
        {
            var passedDueDateLoans = await loanRepository.GetPassedDueDate(membershipId);

            return mapper.Map<List<ResponseBookLoanDto>>(passedDueDateLoans);
        }
    }
}
