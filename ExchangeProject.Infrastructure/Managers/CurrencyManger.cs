using System.Net;
using CurrencyExchangeConvrtrtor.Core.Repositories;
using ExchangeProject.Core.Enums;
using ExchangeProject.Core.Managers;
using ExchangeProject.Core.Models;
using ExchangeProject.Core.Repositories;
using ExchangeProject.Infrastructure.DTOs;
using ExchangeProject.Infrastructure.Models;
using Newtonsoft.Json;

namespace ExchangeProject.Infrastructure.Managers
{
    public class CurrencyManger: ICurrencyManager
    {
        #region private fields and constructors


        private readonly ICurrencyRepository _currencyRepository;

        public CurrencyManger(ICurrencyRepository currencyRepository)
        {
            _currencyRepository = currencyRepository;
        }

        #endregion

        #region Simple methods
        private CurrencyData GetCurrencyFromNet()
        {
            try
            {
                string json = (new WebClient()).DownloadString("https://nbg.gov.ge/gw/api/ct/monetarypolicy/currencies/ka/json");
                return JsonConvert.DeserializeObject<List<CurrencyData>>(json).First();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task GetCurrencyUpdated()
        {
            CurrencyData Items = GetCurrencyFromNet();
            var data = Items.Currencies.Where(o => o.Code == "USD" || o.Code == "RUB" || o.Code == "UAH"|| o.Code=="EUR").ToList();

        
            if (data != null)
                await _currencyRepository.UpdateCurrencyData(ForAll<CurrencyModel, Currency>((IList<CurrencyModel>)data).ToList());
        }

        private IEnumerable<I> ForAll<T,I>(IList<T> data)where T: I
        {
            foreach (T item in data) yield return item;
        }

        public async Task<Currency> GetCurrencyRate(CurrencyType currencyType)
        {
            switch (currencyType)
            {
                case CurrencyType.USD:
                    return await _currencyRepository.GetCurrencyByCode("USD"); ;
                case CurrencyType.RUB:
                    return await _currencyRepository.GetCurrencyByCode("RUB");
                case CurrencyType.EUR:
                    return await _currencyRepository.GetCurrencyByCode("EUR");
                case CurrencyType.UAH:
                    return await _currencyRepository.GetCurrencyByCode("UAH");
                default:
                    return null;
            }
        }
        #endregion
    }
}
