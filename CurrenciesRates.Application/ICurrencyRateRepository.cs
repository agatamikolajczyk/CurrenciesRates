using CurrenciesRates.Application.Models;

namespace CurrenciesRates.Application;

public interface ICurrenciesRatesRepository
{
    public Task<CurrencyRate> GetCurrencyRateAsync(string currencyCode, DateTime date);
}