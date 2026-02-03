using FluentValidation;
using Shared.Dtos.ArchiveDTOs;

namespace Core.Validators.Archive
{
    /// <summary>
    /// Validator لإنشاء سجل أرشيف
    /// </summary>
    public class CreateArchiveDtoValidator : AbstractValidator<CreateArchiveDto>
    {
        public CreateArchiveDtoValidator()
        {
            RuleFor(x => x.EntityType)
                .NotEmpty()
                .WithMessage("نوع الكيان مطلوب")
                .MaximumLength(50)
                .WithMessage("نوع الكيان يجب ألا يزيد عن 50 حرف");

            RuleFor(x => x.EntityID)
                .GreaterThan(0)
                .WithMessage("رقم الكيان غير صحيح");

            RuleFor(x => x.ArchiveData)
                .NotEmpty()
                .WithMessage("بيانات الأرشيف مطلوبة");

            RuleFor(x => x.ArchivedByUserId)
                .GreaterThan(0)
                .WithMessage("يجب تحديد المستخدم الذي قام بالأرشفة");

            RuleFor(x => x.StoragePath)
                .MaximumLength(200)
                .WithMessage("مسار التخزين يجب ألا يزيد عن 200 حرف")
                .When(x => !string.IsNullOrWhiteSpace(x.StoragePath));
        }
    }
}
