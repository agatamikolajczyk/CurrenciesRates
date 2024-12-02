namespace CurrenciesRates.Application.Models;

public class CurrencyRate
{
    public Guid Id { get; set; }
    public string Currency { get; set; }
    public decimal Bid { get; set; }
    public decimal Ask { get; set; }
    public DateTime Date { get; set; }

    public CurrencyRate(string currency, decimal bid, decimal ask, DateTime date)
    {
        Currency = currency;
        Bid = bid;
        Ask = ask;
        Date = date;
    }
}