using Applications.ViewModels;
using FluentValidation;

namespace APIs.Validations.UserValidations
{
    public class WeeklyTimeValidation : AbstractValidator<WeeklyTimeViewModel>
    {
        public WeeklyTimeValidation()
        {
            RuleFor(x => x.StartTime).NotEmpty();
            RuleFor(x => x.EndTime).NotEmpty().GreaterThan(x=>x.StartTime);
            RuleFor(x => x.DayOfWeek).IsInEnum();
        }
    }
}
