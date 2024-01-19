using LibraryManagement.Application.Security.Utils;
using LibraryManagement.Application.Services;
using LibraryManagement.Application.Services.Interfaces;
using LibraryManagement.Infrastructure.Caching;

namespace LibraryManagement.API.ServiceExtensions
{
    public static class RegisterServices
    {
        public static IServiceCollection AddApiServices(this IServiceCollection services)
        {
            services.AddScoped<IAuthorService, AuthorService>();
            services.AddScoped<IBookService, BookService>();
            services.AddScoped<IGenreService, GenreService>();
            services.AddScoped<ILoanService, LoanService>();
            services.AddScoped<IMembershipService, MembershipService>();
            services.AddScoped<IMembershipTypeService, MembershipTypeService>();
            services.AddScoped<IPublisherService, PublisherService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IJwtUtils, JwtUtils>();
            services.AddScoped<IAzureStorageService, AzureStorageService>();
            services.AddSingleton<ICache, MemoryCacheService>();
            services.AddScoped<IBookingService, BookingService>();

            return services;
        }
    }
}
