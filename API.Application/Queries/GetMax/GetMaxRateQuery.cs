using API.Domain.Common;
using API.Domain.DTOs;
using MediatR;

namespace API.Application.Queries.GetMax;

public class GetMaxRateQuery : IRequest<OperationResult<RateDto>>
{
    public GetExchangeRatesRequestDto Dto { get; private set; }
    
    public GetMaxRateQuery(GetExchangeRatesRequestDto dto)
    {
        Dto = dto;
    }
    
}