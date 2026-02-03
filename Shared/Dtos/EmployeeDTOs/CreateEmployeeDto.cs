namespace Shared.DTOs.Employee
{
    public class CreateEmployeeDto
    {
        public string EmployeeCode { get; set; }
        public string FullName { get; set; }
        public string JobTitle { get; set; }
        public string Department { get; set; }
        public int OfficeID { get; set; } // FK → Office
        public string Username { get; set; }
        public string Password { get; set; } // سنقوم بتحويله إلى PasswordHash في الخدمة
        public bool IsActive { get; set; } = true; // افتراضي الموظف نشط
    }
}
