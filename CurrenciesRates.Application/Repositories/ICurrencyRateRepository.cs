using CurrenciesRates.Application.Models;

namespace CurrenciesRates.Application.Repositories;

public interface ICurrenciesRatesRepository
{
    Task<CurrencyRate?> GetAsync(string currencyCode, DateTime date);
    Task SetAsync(CurrencyRate currencyRate);
}