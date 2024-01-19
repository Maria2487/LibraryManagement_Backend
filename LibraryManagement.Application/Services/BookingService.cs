using LibraryManagement.Application.DTOs.Booking;
using LibraryManagement.Application.Services.Interfaces;
using LibraryManagement.Domain.Entities.JoiningEntities;
using LibraryManagement.Infrastructure.Repositories.Interfaces;

namespace LibraryManagement.Application.Services
{
    public class BookingService : IBookingService
    {
        private readonly IBookRepository bookRepository;
        private readonly IMembershipRepository membershipRepository;
        private readonly IUserRepository userRepository;

        public BookingService(IBookRepository bookRepository, IMembershipRepository membershipRepository, 
            IUserRepository userRepository)
        {
            this.bookRepository = bookRepository;
            this.membershipRepository = membershipRepository;
            this.userRepository = userRepository;
        }

        public async Task<ResponseBookingDto> Create(string email, Guid bookId)
        {
            // verify if member has a valid membership
            var user = await userRepository.GetByEmail(email);

            // verify membership
            var membership = await membershipRepository.GetMembership(user.Id);

            if (membership is null)
            {
                throw new Exception("Membership is not valid");
            }

            if (DateTime.UtcNow > membership.EndDate)
            {
                throw new Exception("Membership is expired");
            }

            // get book
            var book = await bookRepository.GetById(bookId);

            if (book is null)
            {
                throw new KeyNotFoundException();
            }

            Bookings booking = new Bookings
            {
                Book = book,
                Membership = membership
            };

            return null;
        }

        public List<ResponseBookingDto> NotifyAvailableBooks(Guid membershipId)
        {
            throw new NotImplementedException();
        }

        Task<List<ResponseBookingDto>> IBookingService.NotifyAvailableBooks(Guid membershipId)
        {
            throw new NotImplementedException();
        }
    }
}
