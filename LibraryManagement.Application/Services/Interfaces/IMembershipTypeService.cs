using LibraryManagement.Application.DTOs.MembershipType;

namespace LibraryManagement.Application.Services.Interfaces
{
    public interface IMembershipTypeService
    {
        Task<ResponseMembershipTypeDto> Create(MembershipTypeDto membershipDto);
        Task<ResponseMembershipTypeDto> GetById(Guid id);
        Task<List<ResponseMembershipTypeDto>> GetAll();
        Task<ResponseMembershipTypeDto> Update(Guid id, MembershipTypeDto membershipDto);
        Task Delete(Guid id);
    }
}
