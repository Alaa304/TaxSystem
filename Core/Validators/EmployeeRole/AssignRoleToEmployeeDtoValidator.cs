using FluentValidation;
using Shared.DTOs.EmployeeRole;

namespace Core.Validators.EmployeeRole
{
    /// <summary>
    /// Validator لتعيين دور لموظف
    /// </summary>
    public class AssignRoleToEmployeeDtoValidator : AbstractValidator<AssignRoleToEmployeeDto>
    {
        public AssignRoleToEmployeeDtoValidator()
        {
            RuleFor(x => x.EmployeeID)
                .GreaterThan(0)
                .WithMessage("رقم الموظف غير صحيح");

            RuleFor(x => x.RoleID)
                .GreaterThan(0)
                .WithMessage("رقم الدور غير صحيح");
        }
    }
}
