namespace CurrenciesRates.Application.Exception;

public class BadRequestException(string? message) : System.Exception(message);