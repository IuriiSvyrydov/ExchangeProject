namespace ExchangeProject.Infrastructure.DTOs;

public class CurrencyDto
{
    public int Id { get; set; }
    public string Code { get; set; }
    public DateTime Dateate { get; set; }
    public decimal Diff { get; set; }
    public string DiffFormated { get; set; }
    public string Name { get; set; }
    public int Quantity { get; set; }
    public decimal Rate { get; set; }
    public string RateFormated { get; set; }
    public DateTime ValidFromDate { get; set; }
}