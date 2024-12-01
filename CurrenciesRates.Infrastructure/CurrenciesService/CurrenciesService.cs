using CurrenciesRates.Application.Models;
using CurrenciesRates.Application.Services;

namespace CurrenciesRates.Infrastructure.CurrenciesService;

public class CurrenciesService : ICurrenciesService
{
    public Task<CurrencyRate> GetCurrencyRateAsync(string currencyCode, DateTime data)
    {
        throw new NotImplementedException();
    }

    public Task<CurrencyRate> GetCurrencyRateTableAsync(string code)
    {
        throw new NotImplementedException();
    }
}