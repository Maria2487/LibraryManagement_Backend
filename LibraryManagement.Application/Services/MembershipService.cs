using AutoMapper;
using LibraryManagement.Application.DTOs.Membership;
using LibraryManagement.Application.Services.Interfaces;
using LibraryManagement.Domain.Entities.RegularEntities;
using LibraryManagement.Infrastructure.Repositories.Interfaces;

namespace LibraryManagement.Application.Services
{
    public class MembershipService : IMembershipService
    {
        public readonly IMembershipRepository membershipRepository;
        public readonly IMapper mapper;

        public MembershipService(IMembershipRepository membershipRepository, IMapper mapper)
        {
            this.membershipRepository = membershipRepository;
            this.mapper = mapper;
        }

        public async Task<ResponseMembershipDto> Create(MembershipDto membershipDto)
        {
            var membership = mapper.Map<Membership>(membershipDto);

            var existingMembership = await membershipRepository.GetMembership(membershipDto.MemberId);

            // If membership doesn't exist, create a new one
            if (existingMembership is null)
            {
                membership.MembershipTypeId = (int)Utils.Enums.MembershipType.Youngling;
                membership.EndDate = DateTime.UtcNow.AddDays(30);
                membership = await membershipRepository.Create(membership);
            }
            else if(DateTime.UtcNow > existingMembership.EndDate)
            {
                // if membership is not valid anymore, renewal
                membership = existingMembership;
                membership.StartDate = membershipDto.StartDate;
                membership.EndDate = membershipDto.StartDate.AddDays(30);
                await membershipRepository.Update(membership);
            }
            else
            {
                // if membership is valid, return
                return null;
            }

            return mapper.Map<ResponseMembershipDto>(membership);
        }

        public async Task Delete(Guid id)
        {
            var membership = await membershipRepository.GetById(id);

            if (membership is null)
            {
                throw new KeyNotFoundException();
            }

            await membershipRepository.Delete(membership);
        }

        public async Task<List<ResponseMembershipDto>> GetAll()
        {
            var memberships = await membershipRepository.GetAll();

            return mapper.Map<List<ResponseMembershipDto>>(memberships);
        }

        public async Task<ResponseMembershipDto> GetById(Guid id)
        {
            var membership = await membershipRepository.GetById(id);

            if (membership is null)
            {
                throw new KeyNotFoundException();
            }

            return mapper.Map<ResponseMembershipDto>(membership);
        }

        public async Task<ResponseMembershipDto> Update(Guid id, MembershipDto membershipDto)
        {
            var membership = await membershipRepository.GetById(id);

            if (membership is null)
            {
                throw new KeyNotFoundException();
            }

            mapper.Map(membershipDto, membership);
            await membershipRepository.Update(membership);

            return mapper.Map<ResponseMembershipDto>(membership);
        }
    }
}
