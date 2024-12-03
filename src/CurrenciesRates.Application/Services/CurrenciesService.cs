using CurrenciesRates.Application.Exception;
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
        ValidateDate(date);

        ValidateCurrencyCode(currencyCode);

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

    private void ValidateCurrencyCode(string currencyCode)
    {
        if (string.IsNullOrWhiteSpace(currencyCode) || currencyCode.Length != 3)
        {
            throw new BadRequestException("Invalid currency code");
        }
    }

    private void ValidateDate(DateTime date)
    {
        if (date.Date > DateTime.Now.Date)
        {
            throw new BadRequestException("The date can not be in the future.");
        }
    }

    private async Task<CurrencyRate> SeedCurrencyRateAsync(string currencyCode, DateTime date)
    {
        var rate = await _currencyRateStore.GetCurrencyRateAsync(currencyCode, date);
        await _currenciesRatesRepository.SetAsync(rate);
        return rate;
    }
}