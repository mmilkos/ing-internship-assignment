namespace API.Domain.DTOs;

public class AvgRateDto
{
    public string Table { get; set; }
    public string Currency { get; set; }
    public string Code { get; set; }
    public float Average { get; set; }
    public Rate Rate { get; set; }
}