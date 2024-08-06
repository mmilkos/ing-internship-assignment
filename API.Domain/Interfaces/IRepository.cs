using API.Domain.DTOs;

namespace API.Domain.Interfaces;

public interface IRepository
{
    Task<ExchangeRate> GetExchangeRates(GetExchangeRatesRequestDto dto);
}