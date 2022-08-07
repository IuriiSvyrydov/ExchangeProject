using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExchangeProject.Core.Models;

namespace CurrencyExchangeConvrtrtor.Core.Repositories
{
    public interface IExchangeRepository
    {
        
        Task AddExchangeDataAsync(Exchange model);
        Task DeleteExchangeDataAsync(int id);
        Task<List<Exchange>> GetAllExchangeDatasAsync();
    }
}
