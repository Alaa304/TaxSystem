namespace Shared.DTOs;

public class PersonCreateDto
{
    public string FullName { get; set; } = null!;
    public string NationalID { get; set; } = null!;
    public string Phone { get; set; } = null!;
    public string Address { get; set; } = null!;
    public int PersonType { get; set; }
}