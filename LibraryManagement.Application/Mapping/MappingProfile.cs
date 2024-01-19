using AutoMapper;
using LibraryManagement.Application.DTOs.Author;
using LibraryManagement.Application.DTOs.Book;
using LibraryManagement.Application.DTOs.Genre;
using LibraryManagement.Application.DTOs.Loan;
using LibraryManagement.Application.DTOs.Membership;
using LibraryManagement.Application.DTOs.MembershipType;
using LibraryManagement.Application.DTOs.Publisher;
using LibraryManagement.Application.DTOs.User;
using LibraryManagement.Domain.Entities.EnumEntities;
using LibraryManagement.Domain.Entities.JoiningEntities;
using LibraryManagement.Domain.Entities.RegularEntities;

namespace LibraryManagement.Application.Mapping
{
    public partial class MappingProfile : Profile
    {
        public MappingProfile()
        {
            ConfigureAuthorMapping();
            ConfigureGenreMapping();
            ConfigureLoanMapping();
            ConfigureBookMapping();
            ConfigureMembershipMapping();
            ConfigurePublisherMapping();
            ConfigureUserMapping();
        }

        private void ConfigureAuthorMapping()
        {
            CreateMap<AuthorDto, Author>();
            CreateMap<Author, ResponseAuthorDto>();
            CreateMap<Author, BookAuthorDto>()
                .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => $"{src.LastName} {src.FirstName}"));
        }

        private void ConfigureBookMapping()
        {
            CreateMap<BookGenre, GenreDto>();
            CreateMap<BookAuthor, ResponseBookDto>();

            CreateMap<BookDto, Book>()
                    .ForMember(dest => dest.Genres, opt => opt.MapFrom(src =>
                        src.GenreIDs!.Select(genreId => new BookGenre { GenreId = genreId }).ToList()))
                    .ForMember(dest => dest.Authors, opt => opt.MapFrom(src =>
                        src.AuthorIds!.Select(authorId => new BookAuthor { AuthorId = authorId }).ToList()));

            CreateMap<Book, ResponseBookDto>()
                .ForMember(dest => dest.Genres, opt => opt.MapFrom(src => src.Genres!.Select(bg => bg.Genre).ToList()))
                .ForMember(dest => dest.Authors, opt => opt.MapFrom(src => src.Authors!.Select(bg => bg.Author).ToList()));

        }

        private void ConfigureGenreMapping()
        {
            CreateMap<GenreDto, Genre>();
            CreateMap<Genre, ResponseGenreDto>();
            CreateMap<Genre, GenreDto>();
        }

        private void ConfigureLoanMapping()
        {
            CreateMap<LoanDto, Loan>();
            CreateMap<Loan, ResponseLoanDto>()
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => Enum.GetName(src.Status)));
            CreateMap<Loan, ResponseBookLoanDto>()
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => Enum.GetName(src.Status)));
        }

        private void ConfigureMembershipMapping()
        {
            CreateMap<MembershipDto, Membership>();
            CreateMap<Membership, ResponseMembershipDto>();
        }

        private void ConfigureMembershipTypeMapping()
        {
            CreateMap<MembershipTypeDto, MembershipType>();
            CreateMap<MembershipType, ResponseMembershipTypeDto>();
        }

        private void ConfigureBookingsMapping()
        {

        }

        private void ConfigurePublisherMapping()
        {
            CreateMap<PublisherDto, Publisher>();
            CreateMap<Publisher, ResponsePublisherDto>();
            CreateMap<Publisher, BookPublisherDto>();
        }

        private void ConfigureUserMapping()
        {
            CreateMap<UserDto, User>();
            CreateMap<User, ResponseUserDto>();
            CreateMap<CreateUserDto, User>();
            CreateMap<User, CreateUserResponseDto>();
            CreateMap<UpdateUserDto, User>();
        }
    }
}
