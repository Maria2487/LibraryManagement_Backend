using LibraryManagement.Application.DTOs.Book;
using LibraryManagement.Application.DTOs.Membership;

namespace LibraryManagement.Application.DTOs.Booking
{
    public class ResponseBookingDto
    {
        public ResponseBookDto Book { get; set; }
        public ResponseMembershipDto Membership { get; set; }
    }
}
