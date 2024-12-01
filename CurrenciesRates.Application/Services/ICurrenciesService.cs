using CurrenciesRates.Application.Models;

namespace CurrenciesRates.Application.Services;

public interface ICurrenciesService
{
    Task<CurrencyRate> GetCurrencyRateAsync(string currencyCode, DateTime data);
    Task<CurrencyRate> GetCurrencyRateTableAsync(string code);
}