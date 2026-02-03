using System;

namespace Core.Domain.Entities
{
    public class SystemLog : BaseEntity<int>
    {
        public int EmployeeID { get; set; }
        public string TableName { get; set; }
        public long RecordID { get; set; }
        public string ActionType { get; set; }
        public string Changes { get; set; } // JSON
        public DateTime ActionDate { get; set; }

        // Navigation
        public Employee Employee { get; set; }
    }
}
