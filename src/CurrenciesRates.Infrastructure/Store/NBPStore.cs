using CurrenciesRates.Application.Models;
using CurrenciesRates.Application.Stores;
using RestEase;

namespace CurrenciesRates.Infrastructure.Store;

public class NBPStore : ICurrencyRateStore
{
    private readonly INBPClientService _nbpClientService;

    public NBPStore()
    {
        _nbpClientService = RestClient.For<INBPClientService>("https://api.nbp.pl/");
    }

    public async Task<CurrencyRate> GetCurrencyRateAsync(string currencyCode, DateTime date)
    {
        var result = await _nbpClientService.GetCurrencyRate("C", currencyCode, date.ToString("yyyy-MM-dd"));
        return result.ToCurrencyRate();
    }
}