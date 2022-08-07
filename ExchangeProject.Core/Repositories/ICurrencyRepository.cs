using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExchangeProject.Core.Models;

namespace CurrencyExchangeConvrtrtor.Core.Repositories
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
