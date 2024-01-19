using LibraryManagement.Infrastructure.Repositories;
using LibraryManagement.Infrastructure.Repositories.Interfaces;

namespace LibraryManagement.API.ServiceExtensions
{
    public static class RegisterRepositories
    {
        public static IServiceCollection AddApiRepositories(this IServiceCollection services)
        {
            services.AddScoped<IAuthorRepository, AuthorRepository>();
            services.AddScoped<IBookRepository, BookRepository>();
            services.AddScoped<IGenreRepository, GenreRepository>();
            services.AddScoped<ILoanRepository, LoanRepository>();
            services.AddScoped<IMembershipRepository, MembershipRepository>();
            services.AddScoped<IMembershipTypeRepository, MembershipTypeRepository>();
            services.AddScoped<IPublisherRepository, PublisherRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
           
            return services;
        }
    }
}
