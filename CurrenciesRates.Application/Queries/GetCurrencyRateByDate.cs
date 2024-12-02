using CurrenciesRates.Application.Dto;
using MediatR;

namespace CurrenciesRates.Application.Queries;

public record GetCurrencyRateByDate(string CurrencyCode, DateTime Date) : IRequest<CurrencyRateDto>;
