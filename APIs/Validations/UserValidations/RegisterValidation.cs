using Applications.ViewModels;
using FluentValidation;

namespace APIs.Validations.UserValidations
{
    public class RegisterValidation : AbstractValidator<RegisterViewModel>
    {
        public RegisterValidation()
        {
            RuleFor(x => x.Email).NotEmpty();
            RuleFor(x => x.FullName).NotEmpty();
            RuleFor(x => x.Password).NotEmpty();
        }
    }
}
