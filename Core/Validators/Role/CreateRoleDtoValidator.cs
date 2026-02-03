using FluentValidation;
using Shared.DTOs.Role;

namespace Core.Validators.Role
{
    /// <summary>
    /// Validator لإنشاء Role
    /// </summary>
    public class CreateRoleDtoValidator : AbstractValidator<CreateRoleDto>
    {
        public CreateRoleDtoValidator()
        {
            RuleFor(x => x.RoleName)
                .NotEmpty()
                .WithMessage("اسم الدور مطلوب")
                .MaximumLength(50)
                .WithMessage("اسم الدور يجب ألا يزيد عن 50 حرف");
        }
    }
}
