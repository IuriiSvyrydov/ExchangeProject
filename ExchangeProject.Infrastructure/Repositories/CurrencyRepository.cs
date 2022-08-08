using AutoMapper;
using CurrencyExchangeConvrtrtor.Core.Repositories;
using ExchangeProject.Core.Models;
using ExchangeProject.Infrastructure.Data;
using System.Linq;
using ExchangeProject.Core.Repositories;
using Microsoft.EntityFrameworkCore;


namespace ExchangeProject.Infrastructure.Repositories
{
    public class CurrencyRepository : ICurrencyRepository
    {
        private readonly CurrencyContext _context;
        private IMapper _mapper;

        public CurrencyRepository(CurrencyContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task AddCurrencyAsync(Currency model)
        {
            var currencyModel = model as Currency;
            var item = _mapper.Map<Currency>(currencyModel);
            _context.Currencies.Add(item);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteCurrencyAsync(int id)
        {
            var currency = await _context.Currencies.FirstOrDefaultAsync(c => c.Id == id);
            if (currency is not  null)
            {
                _context.Currencies.Remove(currency);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<Currency>> GetAllCurrencyDataAsync()
        {
            var currency = await _context.Currencies.ToListAsync();
            var currencyItem = _mapper.Map<List<Currency>>(currency);
            return currencyItem;

        }

        public async Task UpdateCurrencyData(List<Currency> newData)
        {
            if (_context.Currencies.LongCount() != 0)
            {
                foreach (var item in _context.Currencies)
                {
                    _context.Currencies.Remove(item);
                }
                await _context.SaveChangesAsync();
            }
            if (newData.Count == 0) return;
            foreach (var item in newData)
            {
                await AddCurrencyAsync(item);
            }
        }

        public async Task<Currency> GetCurrencyByCode(string code)
        {
            var currencyCode = await _context.Currencies.FirstOrDefaultAsync(c => c.Code == code);
            var item = _mapper.Map<Currency>(currencyCode);
            return item;
        }
    }
}
