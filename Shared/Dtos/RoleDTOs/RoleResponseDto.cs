namespace Shared.DTOs.Role
{
    /// <summary>
    /// DTO لإرجاع بيانات الـ Role
    /// </summary>
    public class RoleResponseDto
    {
        public int RoleID { get; set; }
        public string RoleName { get; set; } = null!;
    }
}
