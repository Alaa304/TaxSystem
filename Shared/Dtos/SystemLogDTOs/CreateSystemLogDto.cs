namespace Shared.DTOs.SystemLog
{
    /// <summary>
    /// DTO لتسجيل عملية في النظام
    /// </summary>
    public class CreateSystemLogDto
    {
        public int EmployeeID { get; set; }
        public string TableName { get; set; } = null!;
        public long RecordID { get; set; }
        public string ActionType { get; set; } = null!;
        public string Changes { get; set; } = null!;
    }
}
