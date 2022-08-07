using ExchangeProject.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ExchangeProject.WEB.Extensions
{
    public static class DataBaseExtensions
    {
        public static IServiceCollection AddDbConnection(this IServiceCollection services,IConfiguration configuration)
        {
            var connection = configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<CurrencyContext>(options =>
            {
                options.UseMySql(connection, ServerVersion.AutoDetect(connection));
            });

            return services;
        }
    }
}
