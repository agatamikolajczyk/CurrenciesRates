using CurrenciesRates.Application.Models;
using CurrenciesRates.Application.Repositories;
using CurrenciesRates.Application.Stores;

namespace CurrenciesRates.Application.Services;

public class CurrenciesService(
    ICurrenciesRatesRepository currenciesRatesRepository,
    ICurrencyRateStore currencyRateStore)
    : ICurrenciesService
{
    private readonly ICurrenciesRatesRepository _currenciesRatesRepository = currenciesRatesRepository;
    private readonly ICurrencyRateStore _currencyRateStore = currencyRateStore;


    public async Task<CurrencyRate> GetCurrencyRateAsync(string currencyCode, DateTime date)
    {
        var currencyRate = await _currenciesRatesRepository.GetAsync(currencyCode, date);
        if (currencyRate != null)
        {
            return currencyRate;
        }
        else
        {
            return await SeedCurrencyRateAsync(currencyCode, date);
        }
    }

    private async Task<CurrencyRate> SeedCurrencyRateAsync(string currencyCode, DateTime date)
    {
        var rate= await _currencyRateStore.GetCurrencyRateAsync(currencyCode, date);
        await _currenciesRatesRepository.SetAsync(rate);
        return rate;
    }

}