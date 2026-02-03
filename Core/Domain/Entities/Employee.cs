using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain.Entities
{
 
        public class Employee : BaseEntity<int>
    {
            public string EmployeeCode { get; set; }
            public string FullName { get; set; }
            public string JobTitle { get; set; }
            public string Department { get; set; }
            public int OfficeID { get; set; } // FK → Office
            public string Username { get; set; }
            public string PasswordHash { get; set; }
            public bool IsActive { get; set; }

            // Navigation Properties
            public Office Office { get; set; }
            public ICollection<EmployeeRole> EmployeeRoles { get; set; }
            public ICollection<SystemLog> SystemLogs { get; set; }
            public ICollection<Archive> Archives { get; set; }
        }
    }
