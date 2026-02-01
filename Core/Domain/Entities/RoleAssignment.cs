namespace Core.Domain.Entities
{
    public enum RoleType
    {
        Owner = 1,        
        Beneficiary = 2  
    }

    public class RoleAssignment : BaseEntity<int>
    {
        public int PersonId { get; set; }
        public Person Person { get; set; } = null!;

        public int UnitId { get; set; }
        public Unit Unit { get; set; } = null!;

        public RoleType RoleType { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        public bool IsActive { get; set; }
    }
}
