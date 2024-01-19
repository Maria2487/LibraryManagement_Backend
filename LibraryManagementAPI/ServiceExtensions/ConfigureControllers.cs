using System.Text.Json;

namespace LibraryManagement.API.ServiceExtensions
{
    public static class ConfigureControllers
    {
        public static IServiceCollection ConfigureControllersOptions(this IServiceCollection services)
        {
            services.AddControllers()
                .AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
                });

            return services;
        }
    }
}
