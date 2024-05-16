using Applications.ViewModels;
using Domain.Enums;
using FluentValidation;

namespace APIs.Validations.UniversityValidations
{
    public class UniversityValidation : AbstractValidator<UniversityViewModel>
    {
        public UniversityValidation()
        {
            RuleFor(x => x.UniversityArea).IsInEnum();
            RuleFor(x => x.UniversityName).NotEmpty();
        }
    }
}
