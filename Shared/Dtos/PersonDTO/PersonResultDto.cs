namespace Shared.DTOs;

public class PersonResultDto
{
    public int Id { get; set; }
    public string FullName { get; set; } = null!;
    public string NationalID { get; set; } = null!;
    public string Phone { get; set; } = null!;
    public string Address { get; set; } = null!;
    public string PersonType { get; set; } = null!;
}