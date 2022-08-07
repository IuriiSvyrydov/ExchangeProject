using AutoMapper;
using CurrencyExchangeConvrtrtor.Core.Repositories;
using ExchangeProject.Core.Enums;
using ExchangeProject.Core.Managers;
using ExchangeProject.Core.Models;
using ExchangeProject.Infrastructure.DTOs;
using ExchangeProject.Infrastructure.Models;

namespace ExchangeProject.Infrastructure.Managers
{
    public class ExchangeManager: IExchangeManager
    {
        private readonly ICurrencyManager _manager;
        private readonly IExchangeRepository _exchangeRepository;
        private readonly IMapper _mapper;

        public ExchangeManager(ICurrencyManager manager, IExchangeRepository exchangeRepository, IMapper mapper)
        {
            _manager = manager;
            _exchangeRepository = exchangeRepository;
            _mapper = mapper;
        }

        public async Task RequestCurrencyExchange(string clientName, string personalNumber, int fromCurrency, int toCurrency,
            decimal amount)
        {
            var conversionCurrency = new ExchangeDto()
            {
                ClientName = clientName,
                PersonalNumber = personalNumber,
                Date = DateTime.Now,
                OriginAmount = amount,
                FromCurrency = (CurrencyType)fromCurrency,
                ToCurrency = (CurrencyType)toCurrency,
            };
            await _manager.GetCurrencyUpdated();
             Currency  currencyData= new CurrencyModel();
            if ((CurrencyType)fromCurrency == CurrencyType.USD)
            {
                currencyData = await _manager.GetCurrencyRate((CurrencyType)toCurrency);
                conversionCurrency.ConvertedAmount = (amount / currencyData.Rate) * currencyData.Quantity;
            }
            else
            {
                currencyData = await _manager.GetCurrencyRate((CurrencyType)fromCurrency);
                conversionCurrency.ConvertedAmount = (amount * currencyData.Rate) / currencyData.Quantity;
            }
            currencyData.Rate = currencyData.Rate;
            var result = _mapper.Map<Exchange>(conversionCurrency);
            await _exchangeRepository.AddExchangeDataAsync(result);
        }
    }
}
