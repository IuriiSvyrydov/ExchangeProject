using ExchangeProject.Infrastructure.DTOs;

namespace ExchangeProject.Infrastructure.Models
{
    public class CurrencyData
    {
        public DateTime Date { get; set; }
        public List<CurrencyDto> Currencies { get; set; }
    }
}
