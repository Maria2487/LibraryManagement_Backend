using LibraryManagement.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagement.API.ServiceExtensions
{
    public static class RegisterDatabase
    {
        public static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            var applicationConnectionString = configuration.GetConnectionString("ApplicationConnectionString");
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(applicationConnectionString));

            return services;
        }
    }
}
