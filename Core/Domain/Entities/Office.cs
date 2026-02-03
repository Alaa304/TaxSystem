using System.Collections.Generic;

namespace Core.Domain.Entities
{
    public class Office : BaseEntity<int>
    {
        public string Governorate { get; set; }
        public string City { get; set; }
        public string OfficeName { get; set; }
        public string OfficeCode { get; set; }

        // Navigation
        public ICollection<Employee> Employees { get; set; }
    }
}
