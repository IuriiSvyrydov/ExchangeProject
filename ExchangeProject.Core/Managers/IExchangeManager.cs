namespace ExchangeProject.Core.Managers
{
    public interface IExchangeManager
    {
        Task RequestCurrencyExchange(string clientName, string personalNumber, int fromCurrency, int toCurrency, decimal amount);
    }
}
