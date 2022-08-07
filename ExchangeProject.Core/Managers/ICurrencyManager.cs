using ExchangeProject.Core.Enums;
using ExchangeProject.Core.Models;

namespace ExchangeProject.Core.Managers
{
    public interface ICurrencyManager
    {
        Task GetCurrencyUpdated();
        Task<Currency> GetCurrencyRate(CurrencyType currencyType);
    }
}
