namespace Shared.DTOs.SystemLog
{
    /// <summary>
    /// DTO لإرجاع بيانات سجل النظام
    /// </summary>
    public class SystemLogResponseDto
    {
        public long LogID { get; set; }
        public string TableName { get; set; } = null!;
        public string ActionType { get; set; } = null!;
        public DateTime ActionDate { get; set; }
    }
}
