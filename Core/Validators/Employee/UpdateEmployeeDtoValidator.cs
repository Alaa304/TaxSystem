using FluentValidation;
using Shared.DTOs.Employee;

namespace Core.Validators.Employee
{
    public class UpdateEmployeeDtoValidator : AbstractValidator<UpdateEmployeeDto>
    {
        public UpdateEmployeeDtoValidator()
        {
            // التحقق من رقم الموظف
            RuleFor(x => x.EmployeeID)
                .GreaterThan(0)
                .WithMessage("رقم الموظف غير صحيح");

            // الاسم الكامل (اختياري، لكن إذا موجود يجب ألا يزيد عن 100 حرف)
            RuleFor(x => x.FullName)
                .MaximumLength(100)
                .WithMessage("اسم الموظف يجب ألا يزيد عن 100 حرف")
                .When(x => !string.IsNullOrWhiteSpace(x.FullName));

            // المسمى الوظيفي (اختياري)
            RuleFor(x => x.JobTitle)
                .MaximumLength(50)
                .WithMessage("المسمى الوظيفي يجب ألا يزيد عن 50 حرف")
                .When(x => !string.IsNullOrWhiteSpace(x.JobTitle));

            // القسم (اختياري)
            RuleFor(x => x.Department)
                .MaximumLength(50)
                .WithMessage("اسم القسم يجب ألا يزيد عن 50 حرف")
                .When(x => !string.IsNullOrWhiteSpace(x.Department));

            // OfficeID لازم يكون أكبر من 0
            RuleFor(x => x.OfficeID)
                .GreaterThan(0)
                .WithMessage("يجب اختيار مكتب صحيح");

            // اسم المستخدم (اختياري)
            RuleFor(x => x.Username)
                .MaximumLength(50)
                .WithMessage("اسم المستخدم يجب ألا يزيد عن 50 حرف")
                .When(x => !string.IsNullOrWhiteSpace(x.Username));

            // كلمة المرور (اختياري)
            RuleFor(x => x.Password)
                .MinimumLength(6)
                .WithMessage("كلمة المرور يجب ألا تقل عن 6 أحرف")
                .When(x => !string.IsNullOrWhiteSpace(x.Password));
        }
    }
}
