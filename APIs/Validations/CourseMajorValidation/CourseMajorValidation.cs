using Applications.ViewModels;
using FluentValidation;

namespace APIs.Validations.CourseMajorValidations
{
    public class CourseMajorValidation : AbstractValidator<CourseMajorViewModel>
    {
        public CourseMajorValidation()
        {
            RuleFor(x => x.CourseMajorName).NotEmpty();
        }
    }
}
