using FluentValidation;
using Shared.DTOs.SystemLog;

namespace Core.Validators.SystemLog
{
    /// <summary>
    /// Validator لإنشاء سجل نظام
    /// يتحقق من صحة البيانات قبل إدخالها في قاعدة البيانات
    /// </summary>
    public class CreateSystemLogDtoValidator : AbstractValidator<CreateSystemLogDto>
    {
        public CreateSystemLogDtoValidator()
        {
            // EmployeeID يجب أن يكون أكبر من 0
            RuleFor(x => x.EmployeeID)
                .GreaterThan(0)
                .WithMessage("يجب تحديد الموظف الذي قام بالعملية");

            // TableName لا يمكن أن يكون فارغ ويجب ألا يزيد عن 50 حرف
            RuleFor(x => x.TableName)
                .NotEmpty()
                .WithMessage("اسم الجدول مطلوب")
                .MaximumLength(50)
                .WithMessage("اسم الجدول يجب ألا يزيد عن 50 حرف");

            // RecordID يجب أن يكون أكبر من 0
            RuleFor(x => x.RecordID)
                .GreaterThan(0)
                .WithMessage("رقم السجل غير صحيح");

            // ActionType لا يمكن أن يكون فارغ ويجب ألا يزيد عن 30 حرف
            RuleFor(x => x.ActionType)
                .NotEmpty()
                .WithMessage("نوع العملية مطلوب")
                .MaximumLength(30)
                .WithMessage("نوع العملية يجب ألا يزيد عن 30 حرف");

            // Changes يجب أن يكون غير فارغ (JSON)
            RuleFor(x => x.Changes)
                .NotEmpty()
                .WithMessage("البيانات المتغيرة (Changes) مطلوبة");
        }
    }
}
