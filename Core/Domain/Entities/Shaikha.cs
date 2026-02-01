namespace Core.Domain.Entities
{
    public class Shaikha : BaseEntity<int>
    {
        public string ShaikhaName { get; set; } = string.Empty;
        public string Governorate { get; set; } = string.Empty;

        public ICollection<Street> Streets { get; set; } = new List<Street>();
    }
}
