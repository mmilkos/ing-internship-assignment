namespace API.Domain.DTOs;

public class ExchangeRate
{
    public string Table { get; set; }
    public string Currency { get; set; }
    public string Code { get; set; }
    public List<Rate> Rates { get; set; }
}