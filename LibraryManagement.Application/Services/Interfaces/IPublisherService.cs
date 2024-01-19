using LibraryManagement.Application.DTOs.Publisher;

namespace LibraryManagement.Application.Services.Interfaces
{
    public interface IPublisherService
    {
        Task<ResponsePublisherDto> Create(PublisherDto publisherDto);
        Task<ResponsePublisherDto> GetById(int id);
        Task<List<ResponsePublisherDto>> GetAll();
        Task<ResponsePublisherDto> Update(int id, PublisherDto publisherDto);
        Task Delete(int id);
    }
}
