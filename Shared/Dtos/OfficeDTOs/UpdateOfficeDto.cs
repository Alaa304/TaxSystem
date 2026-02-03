namespace Shared.DTOs.Office
{
    /// <summary>
    /// DTO لتحديث بيانات المكتب
    /// </summary>
    public class UpdateOfficeDto
    {
        public int OfficeID { get; set; } // رقم تعريف المكتب لتحديده
        public string Governorate { get; set; } = null!; // المحافظة
        public string City { get; set; } = null!; // المدينة
        public string OfficeName { get; set; } = null!; // اسم المكتب
        public string OfficeCode { get; set; } = null!; // كود المكتب
    }
}
