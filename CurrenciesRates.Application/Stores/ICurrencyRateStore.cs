using CurrenciesRates.Application.Models;

namespace CurrenciesRates.Application.Stores;

public interface ICurrencyRateStore
{
    Task<CurrencyRate> GetCurrencyRateAsync(string currencyCode, DateTime date);
}