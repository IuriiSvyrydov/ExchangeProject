using AutoMapper;
using CurrencyExchangeConvrtrtor.Core.Repositories;
using ExchangeProject.Core.Models;
using ExchangeProject.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ExchangeProject.Infrastructure.Repositories
{
    public class ExchangeRepository : IExchangeRepository
    {
        private readonly CurrencyContext _context;
        private IMapper _mapper;
        public ExchangeRepository(CurrencyContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task AddExchangeDataAsync(Exchange model)
        {
            var item = _mapper.Map<Exchange>(model);
            _context.Exchanges.Add(item);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteExchangeDataAsync(int id)
        {
            var record = await _context.Exchanges.FirstOrDefaultAsync(o => o.Id == id);
            if (record != null)
            {
                _context.Exchanges.Remove(record);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<Exchange>> GetAllExchangeDatasAsync()
        {
            return  await _context.Exchanges.ToListAsync();
            
        }
    }
}
