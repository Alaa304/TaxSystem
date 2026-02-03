namespace Shared.Dtos.ArchiveDTOs
{
    /// <summary>
    /// DTO لإنشاء سجل أرشيف
    /// </summary>
    public class CreateArchiveDto
    {
        public string EntityType { get; set; } = null!;
        public long EntityID { get; set; }
        public string ArchiveData { get; set; } = null!;
        public int ArchivedByUserId { get; set; }
        public string? StoragePath { get; set; }
    }
}
