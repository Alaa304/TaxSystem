namespace Core.Domain.Entities
{
    public class Street : BaseEntity<int>
    {
        public string StreetName { get; set; } = string.Empty;

        public int ShaikhaId { get; set; }
        public Shaikha Shaikha { get; set; } = null!;

        public ICollection<Property> Properties { get; set; } = new List<Property>();
    }
}
