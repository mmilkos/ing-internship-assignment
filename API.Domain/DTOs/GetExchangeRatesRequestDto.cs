namespace API.Domain.DTOs;

public class GetExchangeRatesRequestDto
{
    public string Table { get; set; }
    public string Code { get; set; }
    public string Days { get; set; }
}