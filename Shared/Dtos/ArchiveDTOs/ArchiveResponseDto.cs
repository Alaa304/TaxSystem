namespace Shared.Dtos.ArchiveDTOs
{
    /// <summary>
    /// DTO لإرجاع بيانات الأرشيف
    /// </summary>
    public class ArchiveResponseDto
    {
        public long ArchivedID { get; set; }
        public string EntityType { get; set; } = null!;
        public long EntityID { get; set; }
        public DateTime ArchiveDate { get; set; }
    }
}
