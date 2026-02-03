namespace Shared.DTOs.EmployeeRole
{
    /// <summary>
    /// DTO لإزالة دور من موظف
    /// </summary>
    public class RemoveRoleFromEmployeeDto
    {
        public int EmployeeID { get; set; }
        public int RoleID { get; set; }
    }
}
