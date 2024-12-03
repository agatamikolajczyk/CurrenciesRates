using CurrenciesRates.Application.Exception;
using FluentAssertions;

namespace CurrenciesRates.Tests;

public class CurrenciesRatesServiceTest : BaseTests
{
    [Fact]
    public async Task getting_currency_rates_should_return_proper_value()
    {
        string currencyCode = "USD";
        DateTime date = new DateTime(2024,12,03);
        
        //ACT
        var result = await CurrenciesService.GetCurrencyRateAsync(currencyCode, date);
        result.Should().NotBeNull();
        result.Currency.Should().Be(currencyCode);
        result.Date.Should().Be(date);
    }
    
    [Fact]
    public async Task getting_currency_rates_with_success_should_store_in_database()
    {
        string currencyCode = "USD";
        DateTime date = new DateTime(2024,12,03);
        
        //ACT
        await CurrenciesService.GetCurrencyRateAsync(currencyCode, date);
        
        var result = Context.CurrenciesRates.FirstOrDefault(x=>x.Currency == currencyCode && x.Date == date);
        
        result.Should().NotBeNull();
        result.Currency.Should().Be(currencyCode);
        result.Date.Should().Be(date);
    }

    [Fact]
    public async Task getting_currencies_rates_service_throws_exception_with_future_date_should_throw_exception()
    {
        var exception = await  Record.ExceptionAsync(() => CurrenciesService.GetCurrencyRateAsync("EUR", DateTime.Now.AddMonths(1)));

        // Assert
        exception.Should().NotBeNull();
        exception.Should().BeOfType<BadRequestException>();
    }
    
    [Fact]
    public async Task getting_currencies_rates_service_throws_exception_with_wrong_vurrency_code_throw_exception()
    {
        var exception = await  Record.ExceptionAsync(() => CurrenciesService.GetCurrencyRateAsync("", DateTime.Now.AddMonths(1)));

        // Assert
        exception.Should().NotBeNull();
        exception.Should().BeOfType<BadRequestException>();
    }
}