using CurrenciesRates.Application.Dto;
using CurrenciesRates.Application.Exception;
using CurrenciesRates.Application.Models;
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
        if (request.Date.Date > DateTime.Now.Date)
        {
            throw new BadRequestException("The date can not be in the future.");
        }
        
        var result= await _service.GetCurrencyRateAsync(request.CurrencyCode, request.Date);
        return new CurrencyRateDto(result);
    }
}