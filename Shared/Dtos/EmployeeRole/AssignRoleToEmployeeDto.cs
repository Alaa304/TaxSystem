namespace Shared.DTOs.EmployeeRole
{
    /// <summary>
    /// DTO لتعيين دور لموظف
    /// </summary>
    public class AssignRoleToEmployeeDto
    {
        public int EmployeeID { get; set; }
        public int RoleID { get; set; }
    }
}
