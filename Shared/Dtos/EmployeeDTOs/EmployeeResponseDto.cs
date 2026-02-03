namespace Shared.DTOs.Employee
{
    /// <summary>
    /// DTO لإرجاع بيانات الموظف
    /// </summary>
    public class EmployeeResponseDto
    {
        public int EmployeeID { get; set; }
        public string EmployeeCode { get; set; } = null!;
        public string FullName { get; set; } = null!;
        public string JobTitle { get; set; } = null!;
        public string Department { get; set; } = null!;
        public bool IsActive { get; set; }
    }
}
