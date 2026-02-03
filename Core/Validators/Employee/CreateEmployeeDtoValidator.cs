using FluentValidation;
using Shared.DTOs.Employee;

namespace Core.Validators.Employee
{
    public class CreateEmployeeDtoValidator : AbstractValidator<CreateEmployeeDto>
    {
        public CreateEmployeeDtoValidator()
        {
            RuleFor(x => x.EmployeeCode)
                .NotEmpty().WithMessage("كود الموظف مطلوب")
                .MaximumLength(20).WithMessage("كود الموظف يجب ألا يزيد عن 20 حرف");

            RuleFor(x => x.FullName)
                .NotEmpty().WithMessage("اسم الموظف مطلوب")
                .MaximumLength(100).WithMessage("اسم الموظف يجب ألا يزيد عن 100 حرف");

           
            RuleFor(x => x.OfficeID)
                .GreaterThan(0).WithMessage("يجب اختيار مكتب صحيح");

            RuleFor(x => x.Username)
                .NotEmpty().WithMessage("اسم المستخدم مطلوب")
                .MaximumLength(50).WithMessage("اسم المستخدم يجب ألا يزيد عن 50 حرف");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("كلمة المرور مطلوبة")
                .MinimumLength(6).WithMessage("كلمة المرور يجب ألا تقل عن 6 أحرف");
        }
    }
}
