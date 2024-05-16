using Applications.ViewModels;
using FluentValidation;

namespace APIs.Validations.TutorValidations
{
    public class TutorValidation : AbstractValidator<TutorViewModel>
    {
        public TutorValidation()
        {
            //RuleFor(x => x.SelfDescription).NotEmpty();
            //RuleFor(x => x.ExampleVideoStyle).NotEmpty();
            //RuleFor(x => x.AvgRatingStar).NotEmpty();
            //RuleFor(x => x.TutorLocation).NotEmpty();
            //RuleFor(x => x.TutorCourseSold).NotEmpty();
        }
    }
}
