using System.Net;
using API.Domain.Common;
using API.Domain.DTOs;
using API.Domain.Interfaces;
using API.Domain.Resources;
using Flurl.Http;
using MediatR;

namespace API.Application.Queries;

public class GetAllRatesQueryHandler : IRequestHandler<GetAllRatesQuery, OperationResult<ExchangeRate>>
{
    private IRepository _repository;
    
    public GetAllRatesQueryHandler(IRepository repository)
    {
        _repository = repository;
    }
    
    public async Task<OperationResult<ExchangeRate>> Handle(GetAllRatesQuery request, CancellationToken cancellationToken)
    {
        var dto = request.Dto;

        var result = new OperationResult<ExchangeRate>();
        
        ExchangeRate? exchangeRate;  

        try
        {
            exchangeRate = await _repository.GetExchangeRates(dto);
        }
        catch (FlurlHttpException e)
        {
            switch (e.StatusCode)
            {
                case (int)HttpStatusCode.NotFound:
                    result.AddError(Errors.NotFound);
                    break;
                case (int)HttpStatusCode.BadRequest:
                    result.AddError(Errors.BadRequest);
                    break;
                default: 
                    result.AddError(Errors.UnExpected);
                    break;
            }
            
            return result;
        }

        result.Data = exchangeRate;

        return result;
    }
}