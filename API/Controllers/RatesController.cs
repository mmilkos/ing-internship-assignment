using API.Application.Queries;
using API.Application.Queries.GetAvg;
using API.Application.Queries.GetMax;
using API.Application.Queries.GetMin;
using API.Domain.Common;
using API.Domain.DTOs;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace API.Controllers;

[ApiController]
[Route("api/rates")]
public class RatesController : ControllerBase
{
    private IMediator _mediator;
    private readonly DefaultRatesOptions _ratesOptions;

    public RatesController(IMediator mediator, IOptions<DefaultRatesOptions> options)
    {
        _mediator = mediator;
        _ratesOptions = options.Value;
    }

    [HttpGet]
    public async Task<ActionResult<ExchangeRate>> GetAllRates([FromQuery] string? currencyCode, [FromQuery] string? days, [FromQuery] string? table )
    {
        var dto = new GetExchangeRatesRequestDto()
        {
            Code = currencyCode ?? _ratesOptions.Code,
            Days = days ?? _ratesOptions.Days,
            Table = table ?? _ratesOptions.Table
        };
        
        var result = await _mediator.Send(new GetAllRatesQuery(dto));

        if (result.Success) return Ok(result.Data);

        return StatusCode(500, result.ErrorsList);
    }
    
    
    [HttpGet("min")]
    public async Task<ActionResult<RateDto>>  GetMinRate([FromQuery] string? currencyCode, [FromQuery] string? days, [FromQuery] string? table)
    {
        var dto = new GetExchangeRatesRequestDto()
        {
            Code = currencyCode ?? _ratesOptions.Code,
            Days = days ?? _ratesOptions.Days,
            Table = table ?? _ratesOptions.Table
        };
        
        var result = await _mediator.Send(new GetMinRateQuery(dto));

        if (result.Success) return Ok(result.Data);

        return StatusCode(500, result.ErrorsList);
    }
    
    
    [HttpGet("max")]
    public async Task<ActionResult<RateDto>>  GetMaxRate([FromQuery] string? currencyCode, [FromQuery] string? days, [FromQuery] string? table)
    {
        var dto = new GetExchangeRatesRequestDto()
        {
            Code = currencyCode ?? _ratesOptions.Code,
            Days = days ?? _ratesOptions.Days,
            Table = table ?? _ratesOptions.Table
        };
        
        var result = await _mediator.Send(new GetMaxRateQuery(dto));

        if (result.Success) return Ok(result.Data);

        return StatusCode(500, result.ErrorsList);
    }
    
    [HttpGet("avg")]
    public async Task<ActionResult<AvgRateDto>> GetAvgRate([FromQuery] string? currencyCode, [FromQuery] string? days, [FromQuery] string? table)
    {
        var dto = new GetExchangeRatesRequestDto()
        {
            Code = currencyCode ?? _ratesOptions.Code,
            Days = days ?? _ratesOptions.Days,
            Table = table ?? _ratesOptions.Table
        };
        
        var result = await _mediator.Send(new GetAvgRateQuery(dto));

        if (result.Success) return Ok(result.Data);

        return StatusCode(500, result.ErrorsList);
    }
}