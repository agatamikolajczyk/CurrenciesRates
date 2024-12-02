using CurrenciesRates.Application.Models;
using CurrenciesRates.Application.Repositories;
using CurrenciesRates.Infrastructure.EF;
using Microsoft.EntityFrameworkCore;

namespace CurrenciesRates.Infrastructure.Repositories;

public class CurrenciesRatesRepository(CurrenciesRatesContext context) : ICurrenciesRatesRepository
{
    private readonly CurrenciesRatesContext _context = context;

    public async Task<CurrencyRate?> GetAsync(string currencyCode, DateTime date)
    {
        return await _context.CurrenciesRates.FirstOrDefaultAsync(x=>x.Currency==currencyCode && x.Date == date.Date);
    }

    public async Task SetAsync(CurrencyRate currencyRate)
    {
        _context.CurrenciesRates.Add(currencyRate);
        await _context.SaveChangesAsync();
    }
}