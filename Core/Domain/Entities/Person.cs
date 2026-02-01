using System;
using System.Collections.Generic;
namespace Core.Domain.Entities
{
 public enum PersonType
{
    Individual = 1,
    Company = 2,
    Government = 3
}

public class Person: BaseEntity<int>
{
    public string NationalID { get; set; } = null!;
    public string FullName { get; set; } = null!;
    public string Phone { get; set; } = null!;
    public string Address { get; set; } = null!;
    public PersonType PersonType { get; set; }
    public bool IsActive { get; set; }
       public ICollection<RoleAssignment> RoleAssignments { get; set; }
        = new List<RoleAssignment>();
}


}