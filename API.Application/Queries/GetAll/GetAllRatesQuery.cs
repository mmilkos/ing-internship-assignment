using API.Domain.Common;
using API.Domain.DTOs;
using MediatR;

namespace API.Application.Queries;

public class GetAllRatesQuery : IRequest<OperationResult<ExchangeRate>>
{
    public GetExchangeRatesRequestDto Dto { get; private set; }
    
    public GetAllRatesQuery(GetExchangeRatesRequestDto dto)
    {
        Dto = dto;
    }
}