using API.Domain.Common;
using API.Domain.DTOs;
using MediatR;

namespace API.Application.Queries.GetMin;

public class GetMinRateQuery : IRequest<OperationResult<RateDto>>
{
    public GetExchangeRatesRequestDto Dto { get; private set; }
    
    public GetMinRateQuery(GetExchangeRatesRequestDto dto)
    {
        Dto = dto;
    }
    
}