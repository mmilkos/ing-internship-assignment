using API.Domain.DTOs;
using API.Domain.Interfaces;
using Flurl.Http;
using Microsoft.Extensions.Configuration;

namespace API.Infrastructure.Repositories;

public class Repository : IRepository
{
    private readonly string _url;
    
    public Repository(IConfiguration configuration)
    {
        _url = configuration.GetConnectionString("NBP");
    }
    
    public async Task<ExchangeRate> GetExchangeRates(GetExchangeRatesRequestDto dto)
    {
        var url = _url + $"/{dto.Table}/{dto.Code}/last/{dto.Days}";

        var result = await url.GetAsync().ReceiveJson<ExchangeRate>();

        return result;
    }
}