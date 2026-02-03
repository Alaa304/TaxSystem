namespace Shared.DTOs.Office
{
    /// <summary>
    /// DTO لإرجاع بيانات المكتب
    /// </summary>
    public class OfficeResponseDto
    {
        public int OfficeID { get; set; }
        public string Governorate { get; set; } = null!;
        public string City { get; set; } = null!;
        public string OfficeName { get; set; } = null!;
        public string OfficeCode { get; set; } = null!;
    }
}
