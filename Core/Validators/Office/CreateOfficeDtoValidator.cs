using FluentValidation;
using Shared.DTOs.Office;

namespace Core.Validators.Office
{
    /// <summary>
    /// Validator لإنشاء مكتب جديد
    /// </summary>
    public class CreateOfficeDtoValidator : AbstractValidator<CreateOfficeDto>
    {
        public CreateOfficeDtoValidator()
        {
            RuleFor(x => x.Governorate)
                .NotEmpty()
                .WithMessage("المحافظة مطلوبة")
                .MaximumLength(50)
                .WithMessage("اسم المحافظة يجب ألا يزيد عن 50 حرف");

            RuleFor(x => x.City)
                .NotEmpty()
                .WithMessage("المدينة مطلوبة")
                .MaximumLength(50)
                .WithMessage("اسم المدينة يجب ألا يزيد عن 50 حرف");

            RuleFor(x => x.OfficeName)
                .NotEmpty()
                .WithMessage("اسم المكتب مطلوب")
                .MaximumLength(100)
                .WithMessage("اسم المكتب يجب ألا يزيد عن 100 حرف");

            RuleFor(x => x.OfficeCode)
                .NotEmpty()
                .WithMessage("كود المكتب مطلوب")
                .MaximumLength(20)
                .WithMessage("كود المكتب يجب ألا يزيد عن 20 حرف");
        }
    }
}
