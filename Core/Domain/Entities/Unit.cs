using Shared;

namespace Core.Domain.Entities
{
 
      public class Unit : BaseEntity<int>
    {
        public int PropertyId { get; set; }
        public Property Property { get; set; } = null!;

        public string UnitNumber { get; set; } = null!;
        public int Floor { get; set; }
        public double Area { get; set; }

        public UsageType UsageType { get; set; }
        public FinishingType FinishingType { get; set; }
        public UnitStatus Status { get; set; }

        public ICollection<RoleAssignment> RoleAssignments { get; set; } = new List<RoleAssignment>();
    }
}
