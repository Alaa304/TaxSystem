namespace Core.Domain.Entities
{
    public class EmployeeRole : BaseEntity<int>
    {
        // Composite Key (EmployeeID + RoleID)
        public int EmployeeID { get; set; }
        public int RoleID { get; set; }

        // Navigation
        public Employee Employee { get; set; }
        public Role Role { get; set; }
    }
}
