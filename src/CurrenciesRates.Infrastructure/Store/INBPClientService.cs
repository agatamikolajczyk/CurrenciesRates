using CurrenciesRates.Infrastructure.Store.Models;
using RestEase;

namespace CurrenciesRates.Infrastructure.Store;

public interface INBPClientService
{
    [Get("api/exchangerates/rates/{table}/{code}/{date}/")]
    Task<NBPCurrencyRate> GetCurrencyRate([Path] string table, [Path] string code, [Path] string date, [Query] string format="json");
}