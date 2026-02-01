namespace Core.Domain.Entities
{
    public class Property : BaseEntity<int>
    {
        public string CurrentPropertyNo { get; set; } = null!;
        public string? OldPropertyNo { get; set; }
        public string? PlanningNo { get; set; }

        public int BuildYear { get; set; }

        public int StreetId { get; set; }
        public Street Street { get; set; } = null!;

        public string Description { get; set; } = null!;

        public ICollection<Unit> Units { get; set; } = new List<Unit>();
    }
}
