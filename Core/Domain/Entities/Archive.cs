using System;

namespace Core.Domain.Entities
{
    public class Archive : BaseEntity<int>
    {
        public string EntityType { get; set; }
        public long EntityID { get; set; }
        public string ArchiveData { get; set; } // JSON
        public DateTime ArchiveDate { get; set; }
        public int ArchivedByUserId { get; set; }
        public string StoragePath { get; set; }

        // Navigation
        public Employee ArchivedByUser { get; set; }
    }
}
