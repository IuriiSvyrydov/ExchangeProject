using ExchangeProject.Core.Models;

namespace ExchangeProject.Infrastructure.Models
{
    public class CurrencyModel: Currency
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public int Quantity { get; set; }
        public string RateFormated { get; set; }
        public string DiffFormated { get; set; }
        public decimal Rate { get; set; }
        public string Name { get; set; }
        public decimal Diff { get; set; }
        public DateTime Date { get; set; }
        public DateTime ValidFromDate { get; set; }
    }
}

