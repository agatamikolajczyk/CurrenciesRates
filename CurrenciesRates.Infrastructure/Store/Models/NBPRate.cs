namespace CurrenciesRates.Infrastructure.Store.Models;

public record NBPRate(string No, DateTime EffectiveDate, decimal Bid, decimal Ask);