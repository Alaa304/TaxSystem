namespace Shared.DTOs.Role
{
    /// <summary>
    /// DTO لتحديث Role موجود
    /// </summary>
    public class UpdateRoleDto
    {
        public int RoleID { get; set; }
        public string RoleName { get; set; } = null!;
    }
}
