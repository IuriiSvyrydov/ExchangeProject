using ExchangeProject.Core.Models;

namespace ExchangeProject.Core.Repositories
{
    public interface ICurrencyRepository
    {
        Task AddCurrencyAsync(Currency model);
        Task DeleteCurrencyAsync(int id);
        Task<List<Currency>> GetAllCurrencyDataAsync();
        Task UpdateCurrencyData(List<Currency> newData);
        Task<Currency> GetCurrencyByCode(string code);
    }
}
