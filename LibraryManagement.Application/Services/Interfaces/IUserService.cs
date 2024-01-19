using LibraryManagement.Application.DTOs.Account;
using LibraryManagement.Application.DTOs.User;

namespace LibraryManagement.Application.Services.Interfaces
{
    public interface IUserService
    {
        Task<CreateUserResponseDto> Create(CreateUserDto userDto);
        Task<CreateUserResponseDto> GetById(Guid id);
        Task<List<CreateUserResponseDto>> GetAll();
        Task<CreateUserResponseDto> Update(Guid id, UpdateUserDto useDto);
        Task Delete(Guid id);
        Task<LoginResponseDto> Login(LoginDto loginData);
    }
}
