namespace API.Domain.DTOs;

public class RateDto
{
    public string Table { get; set; }
    public string Currency { get; set; }
    public string Code { get; set; }
    public Rate Rate { get; set; }
}