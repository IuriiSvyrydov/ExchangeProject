namespace ExchangeProject.WEB.Models
{
    public class ConversionRequestViewModel
    {
        public string clientName { get; set; }
        public string personalNumber { get; set; }
        public int fromCurrency { get; set; }
        public int toCurrency { get; set; }
        public string Date { get; set; }
        public decimal amountToConvert { get; set; }
    }
}
