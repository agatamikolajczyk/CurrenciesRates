using CurrenciesRates.Application.Models;

namespace CurrenciesRates.Infrastructure.Store.Models;

public record NBPCurrencyRate(string Table, string Currency, string Code, ICollection<NBPRate> Rates)
{
    public CurrencyRate ToCurrencyRate()
    {
        var rate = Rates.First();
        return new CurrencyRate(Code, rate.Bid, rate.Ask, rate.EffectiveDate);
    }
}
