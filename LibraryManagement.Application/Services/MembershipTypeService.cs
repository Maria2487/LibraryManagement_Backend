using AutoMapper;
using LibraryManagement.Application.DTOs.MembershipType;
using LibraryManagement.Application.Services.Interfaces;
using LibraryManagement.Domain.Entities.RegularEntities;
using LibraryManagement.Infrastructure.Repositories.Interfaces;

namespace LibraryManagement.Application.Services
{
    public class MembershipTypeService : IMembershipTypeService
    {
        public readonly IMembershipTypeRepository membershipTypeRepository;
        public readonly IMapper mapper;

        public MembershipTypeService(IMembershipTypeRepository membershipTypeRepository, IMapper mapper)
        {
            this.membershipTypeRepository = membershipTypeRepository;
            this.mapper = mapper;
        }

        public async Task<ResponseMembershipTypeDto> Create(MembershipTypeDto membershipTypeDto)
        {
            var entity = mapper.Map<MembershipType>(membershipTypeDto);
            var membershipType = await membershipTypeRepository.Create(entity);

            return mapper.Map<ResponseMembershipTypeDto>(membershipType);
        }

        public async Task Delete(Guid id)
        {
            var membershipType = await membershipTypeRepository.GetById(id);

            if (membershipType is null)
            {
                throw new KeyNotFoundException();
            }

            await membershipTypeRepository.Delete(membershipType);
        }

        public async Task<List<ResponseMembershipTypeDto>> GetAll()
        {
            var membershipTypes = await membershipTypeRepository.GetAll();

            return mapper.Map<List<ResponseMembershipTypeDto>>(membershipTypes);
        }

        public async Task<ResponseMembershipTypeDto> GetById(Guid id)
        {
            var membershipType = await membershipTypeRepository.GetById(id);

            if (membershipType is null)
            {
                throw new KeyNotFoundException();
            }

            return mapper.Map<ResponseMembershipTypeDto>(membershipType);
        }

        public async Task<ResponseMembershipTypeDto> Update(Guid id, MembershipTypeDto membershipTypeDto)
        {
            var membershipType = await membershipTypeRepository.GetById(id);

            if (membershipType is null)
            {
                throw new KeyNotFoundException();
            }

            mapper.Map(membershipTypeDto, membershipType);
            await membershipTypeRepository.Update(membershipType);

            return mapper.Map<ResponseMembershipTypeDto>(membershipType);
        }
    }
}
