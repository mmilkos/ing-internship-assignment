using API.Domain.Common;
using API.Domain.DTOs;
using MediatR;

namespace API.Application.Queries.GetMin;

public class GetMinRateQueryHandler : IRequestHandler<GetMinRateQuery, OperationResult<RateDto>>
{
    private readonly IMediator _mediator;
    
    public GetMinRateQueryHandler(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    public async Task<OperationResult<RateDto>> Handle(GetMinRateQuery request, CancellationToken cancellationToken)
    {
        var result = new OperationResult<RateDto>() { };
        
        var rates = await _mediator.Send(new GetAllRatesQuery(request.Dto), cancellationToken);

        foreach (var error in rates.ErrorsList)
        {
            result.AddError(error);
        }

        if (result.Success == false) return result;

        result.Data = new RateDto()
        {
            Code = rates.Data.Code,
            Currency = rates.Data.Currency,
            Table = rates.Data.Table,
            Rate = rates.Data.Rates.MinBy(r => r.mid)
        };

        return result;
    }
}