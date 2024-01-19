using LibraryManagement.Application.DTOs.Membership;

namespace LibraryManagement.Application.Services.Interfaces
{
    public interface IMembershipService
    {
        Task<ResponseMembershipDto> Create(MembershipDto membershipDto);
        Task<ResponseMembershipDto> GetById(Guid id);
        Task<List<ResponseMembershipDto>> GetAll();
        Task<ResponseMembershipDto> Update(Guid id, MembershipDto membershipDto);
        Task Delete(Guid id);
    }
}
