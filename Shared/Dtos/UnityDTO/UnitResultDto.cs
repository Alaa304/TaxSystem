namespace Shared.DTOs;

public class UnitResultDto
{
    public int Id { get; set; }
    public string UnitNumber { get; set; } = null!;
    public int Floor { get; set; }
    public double Area { get; set; }
    public string UsageType { get; set; } = null!;
    public string FinishingType { get; set; } = null!;
    public string Status { get; set; } = null!;
    public int PropertyId { get; set; }
}