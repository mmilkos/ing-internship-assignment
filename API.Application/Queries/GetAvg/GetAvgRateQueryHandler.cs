using API.Domain.Common;
using API.Domain.DTOs;
using MediatR;

namespace API.Application.Queries.GetAvg;

public class GetAvgRateQueryHandler : IRequestHandler<GetAvgRateQuery, OperationResult<AvgRateDto>>
{
    private readonly IMediator _mediator;

    public GetAvgRateQueryHandler(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    public async Task<OperationResult<AvgRateDto>> Handle(GetAvgRateQuery request, CancellationToken cancellationToken)
    {
        var result = new OperationResult<AvgRateDto>();
        
        var rates = await _mediator.Send(new GetAllRatesQuery(request.Dto), cancellationToken);

        foreach (var error in rates.ErrorsList)
        {
            result.AddError(error);
        }

        if (result.Success == false) return result;
        
        var avg = rates.Data.Rates.Average(r => r.mid);

        result.Data = new AvgRateDto()
        {
            Code = rates.Data.Code,
            Currency = rates.Data.Currency,
            Table = rates.Data.Table,
            Average =  rates.Data.Rates.Average(r => r.mid),
            Rate = rates.Data.Rates.OrderBy(rate => Math.Abs(rate.mid - avg)).FirstOrDefault()
        };

        return result;
    }
}