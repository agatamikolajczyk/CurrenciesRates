using CurrenciesRates.Application.Repositories;
using CurrenciesRates.Application.Services;
using CurrenciesRates.Application.Stores;
using CurrenciesRates.Infrastructure.EF;
using CurrenciesRates.Infrastructure.Repositories;
using CurrenciesRates.Infrastructure.Store;
using Microsoft.EntityFrameworkCore;

namespace CurrenciesRates.Tests;

public class BaseTests
{
    protected CurrenciesRatesContext Context { get; set; }
    private ICurrenciesRatesRepository Repository { get; set; }
    private ICurrencyRateStore CurrencyRateStore { get; set; }
    protected ICurrenciesService CurrenciesService { get; set; }

    public BaseTests()
    {
        Context = GetContext();
        Repository = new CurrenciesRatesRepository(Context);
        CurrencyRateStore = new NBPStore();
        CurrenciesService = new CurrenciesService(Repository, CurrencyRateStore);
    }

    CurrenciesRatesContext GetContext()
    {
        var options = new DbContextOptionsBuilder<CurrenciesRatesContext>()
            .UseSqlite("Data Source=:memory:")
            .Options;

        var context = new CurrenciesRatesContext(options);

        context.Database.OpenConnection();
        context.Database.EnsureCreated();

        return context;
    }
}