using AutoMapper;
using LibraryManagement.Application.DTOs.Publisher;
using LibraryManagement.Application.Services.Interfaces;
using LibraryManagement.Domain.Entities.EnumEntities;
using LibraryManagement.Infrastructure.Repositories.Interfaces;

namespace LibraryManagement.Application.Services
{
    public class PublisherService : IPublisherService
    {
        public readonly IPublisherRepository publisherRepository;
        public readonly IMapper mapper;

        public PublisherService(IPublisherRepository publisherRepository, IMapper mapper)
        {
            this.publisherRepository = publisherRepository;
            this.mapper = mapper;
        }

        public async Task<ResponsePublisherDto> Create(PublisherDto publisherDto)
        {
            var entity = mapper.Map<Publisher>(publisherDto);
            var publisher = await publisherRepository.Create(entity);

            return mapper.Map<ResponsePublisherDto>(publisher);
        }

        public async Task Delete(int id)
        {
            var publisher = await publisherRepository.GetById(id);

            if (publisher is null)
            {
                throw new KeyNotFoundException();
            }

            await publisherRepository.Delete(publisher);
        }

        public async Task<List<ResponsePublisherDto>> GetAll()
        {
            var publishers = await publisherRepository.GetAll();

            return mapper.Map<List<ResponsePublisherDto>>(publishers);
        }

        public async Task<ResponsePublisherDto> GetById(int id)
        {
            var publisher = await publisherRepository.GetById(id);

            if (publisher is null)
            {
                throw new KeyNotFoundException();
            }

            return mapper.Map<ResponsePublisherDto>(publisher);
        }

        public async Task<ResponsePublisherDto> Update(int id, PublisherDto publisherDto)
        {
            var publisher = await publisherRepository.GetById(id);

            if (publisher is null)
            {
                throw new KeyNotFoundException();
            }

            mapper.Map(publisherDto, publisher);
            await publisherRepository.Update(publisher);

            return mapper.Map<ResponsePublisherDto>(publisher);
        }
    }
}
