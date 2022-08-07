using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace ExchangeProject.Infrastructure.Data;

public class DesignTimeFactory : IDesignTimeDbContextFactory<CurrencyContext>
{
    public CurrencyContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<CurrencyContext>();
        string connection = "server=127.0.0.1;user=root;password=test123;database=currencydb;port=3306;";
        optionsBuilder.UseMySql(connection,ServerVersion
            .AutoDetect(connection));

        return new CurrencyContext(optionsBuilder.Options);
    }
}