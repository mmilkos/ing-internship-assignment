using API.Domain.Common;
using API.Domain.DTOs;
using MediatR;

namespace API.Application.Queries.GetAvg;

public class GetAvgRateQuery : IRequest<OperationResult<AvgRateDto>>
{
    public GetExchangeRatesRequestDto Dto { get; private set; }
    
    public GetAvgRateQuery(GetExchangeRatesRequestDto dto)
    {
        Dto = dto;
    }
}