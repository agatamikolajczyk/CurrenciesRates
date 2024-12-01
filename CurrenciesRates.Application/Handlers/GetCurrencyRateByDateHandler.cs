using CurrenciesRates.Application.Exception;
using CurrenciesRates.Application.Queries;
using MediatR;

namespace CurrenciesRates.Application.Handlers;

public class GetCurrencyRateByDateHandler: IRequestHandler<GetCurrencyRateByDate, string>
{
    public Task<string> Handle(GetCurrencyRateByDate request, CancellationToken cancellationToken)
    {
        if (request.Date.Date > DateTime.Now.Date)
        {
            throw new BadRequestException("The date can not be in the future.");
        }
        
        return Task.FromResult("Currency Rate ");
    }
}