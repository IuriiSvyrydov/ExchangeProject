using ExchangeProject.Infrastructure.Managers;
using ExchangeProject.Infrastructure.Repositories;
using ExchangeProject.Core.Repositories;

namespace ExchangeProject.WEB.Extensions
{
    public static class ApplicationExtensions
    {
        public static IServiceCollection AddApplicationExtensions(this IServiceCollection services)
        {
            services.AddScoped<ICurrencyRepository, CurrencyRepository>();
            services.AddScoped<ICurrencyManager, CurrencyManger>();
            services.AddScoped<IExchangeRepository, ExchangeRepository>();
            services.AddScoped<IExchangeManager, ExchangeManager>();
            services.AddAutoMapper(typeof(Program));
            return services;
        }
    }
}
