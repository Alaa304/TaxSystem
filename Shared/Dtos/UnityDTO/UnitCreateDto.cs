namespace Shared.DTOs;


public class UnitCreateDto
{
    public string UnitNumber { get; set; } = null!;
    public int Floor { get; set; }
    public double Area { get; set; }
    public int UsageType { get; set; }
    public int FinishingType { get; set; }
    public int Status { get; set; }
    public int PropertyId { get; set; }
}