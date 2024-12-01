namespace CurrenciesRates.Application.Models;

public class CurrencyRate
{
    public Guid Id { get; set; }
    public string Currency { get; set; }
    public string Bid { get; set; }
    public string Ask { get; set; }
    public DateTime Date { get; set; }
}