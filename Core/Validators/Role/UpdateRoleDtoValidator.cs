using FluentValidation;
using Shared.DTOs.Role;

namespace Core.Validators.Role
{
    /// <summary>
    /// Validator لتحديث Role
    /// </summary>
    public class UpdateRoleDtoValidator : AbstractValidator<UpdateRoleDto>
    {
        public UpdateRoleDtoValidator()
        {
            RuleFor(x => x.RoleID)
                .GreaterThan(0)
                .WithMessage("رقم الدور غير صحيح");

            RuleFor(x => x.RoleName)
                .NotEmpty()
                .WithMessage("اسم الدور مطلوب")
                .MaximumLength(50)
                .WithMessage("اسم الدور يجب ألا يزيد عن 50 حرف");
        }
    }
}
