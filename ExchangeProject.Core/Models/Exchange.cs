using System.ComponentModel.DataAnnotations;
using ExchangeProject.Core.Enums;

namespace ExchangeProject.Core.Models
{
    public class Exchange
    {
        [Key]
       public int Id { get; set; }
        public string ClientName { get; set; }
        public string PersonalNumber { get; set; }
        public CurrencyType FromCurrency { get; set; }
        public CurrencyType ToCurrency { get; set; }
        public decimal Rate { get; set; }
        public decimal OriginAmount { get; set; }
        public decimal ConvertedAmount { get; set; }
        public DateTime Date { get; set; }
    }
}
