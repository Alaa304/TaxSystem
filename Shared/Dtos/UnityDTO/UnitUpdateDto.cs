namespace Shared.DTOs;

public class UnitUpdateDto
{
    public string UnitNumber { get; set; } = null!;
    public int Floor { get; set; }
    public double Area { get; set; }
    public int UsageType { get; set; }
    public int FinishingType { get; set; }
    public int Status { get; set; }
}