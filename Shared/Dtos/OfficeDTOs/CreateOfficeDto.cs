namespace Shared.DTOs.Office
{
    /// <summary>
    /// DTO لإنشاء مكتب جديد
    /// </summary>
    public class CreateOfficeDto
    {
        public string Governorate { get; set; } = null!;
        public string City { get; set; } = null!;
        public string OfficeName { get; set; } = null!;
        public string OfficeCode { get; set; } = null!;
    }
}
