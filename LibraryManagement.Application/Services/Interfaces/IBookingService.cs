using LibraryManagement.Application.DTOs.Booking;

namespace LibraryManagement.Application.Services.Interfaces
{
    public interface IBookingService
    {
        Task<ResponseBookingDto> Create(string email, Guid bookId);
        Task<List<ResponseBookingDto>> NotifyAvailableBooks(Guid membershipId);
    }
}
