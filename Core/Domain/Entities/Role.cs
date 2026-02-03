using System.Collections.Generic;

namespace Core.Domain.Entities
{
    public class Role : BaseEntity<int>
    {
        public string RoleName { get; set; }

        // Navigation
        public ICollection<EmployeeRole> EmployeeRoles { get; set; }
    }
}
