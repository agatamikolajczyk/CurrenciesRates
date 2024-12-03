using CurrenciesRates.Application.Dto;
using CurrenciesRates.Application.Queries;
using CurrenciesRates.Application.Services;
using MediatR;

namespace CurrenciesRates.Application.Handlers;

public class GetCurrencyRateByDateHandler: IRequestHandler<GetCurrencyRateByDate, CurrencyRateDto>
{
    private readonly ICurrenciesService _service;

    public GetCurrencyRateByDateHandler(ICurrenciesService service)
    {
        _service = service;
    }

    public async Task<CurrencyRateDto> Handle(GetCurrencyRateByDate request, CancellationToken cancellationToken)
    {
        var result= await _service.GetCurrencyRateAsync(request.CurrencyCode, request.Date);
        return new CurrencyRateDto(result);
    }
}