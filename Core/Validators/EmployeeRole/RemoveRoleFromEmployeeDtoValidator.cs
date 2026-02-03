using FluentValidation;
using Shared.DTOs.EmployeeRole;

namespace Core.Validators.EmployeeRole
{
    /// <summary>
    /// Validator لإزالة دور من موظف
    /// </summary>
    public class RemoveRoleFromEmployeeDtoValidator : AbstractValidator<RemoveRoleFromEmployeeDto>
    {
        public RemoveRoleFromEmployeeDtoValidator()
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
