namespace Shared.DTOs.Employee
{
    public class UpdateEmployeeDto
    {
        public int EmployeeID { get; set; }  // مهم للتعرف على الموظف
        public string? FullName { get; set; }
        public string? JobTitle { get; set; }
        public string? Department { get; set; }
        public int OfficeID { get; set; } // FK → Office
        public string? Username { get; set; }  // إذا حابة تسمحي بتحديث اسم المستخدم
        public string? Password { get; set; }  // إذا حابة تسمحي بتحديث كلمة المرور
        public bool? IsActive { get; set; }   // إذا حابة تغير حالة الموظف
    }
}
