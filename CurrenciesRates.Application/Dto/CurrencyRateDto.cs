using CurrenciesRates.Application.Models;

namespace CurrenciesRates.Application.Dto;

public record CurrencyRateDto(string Currency, decimal Bid, decimal Ask, string Date)
{
    public CurrencyRateDto(CurrencyRate currencyRate) : this(currencyRate.Currency, currencyRate.Bid, currencyRate.Ask,
        currencyRate.Date.ToString("yyyy-MM-dd"))
    {
    }
}