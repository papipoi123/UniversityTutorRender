using Applications.ViewModels;
using FluentValidation;

namespace APIs.Validations.UserValidations
{
    public class UserValidation : AbstractValidator<UserViewModel>
    {
        public UserValidation()
        {
            RuleFor(x => x.FullName).NotEmpty();
            RuleFor(x => x.Email).NotEmpty();
            RuleFor(x => x.Password).NotEmpty();
            RuleFor(x => x.DateOfBirth).NotEmpty();
            RuleFor(x => x.PhoneNumber).NotEmpty();
            RuleFor(x => x.JoinDate).NotEmpty();
            RuleFor(x => x.SelfDecription).NotEmpty();
        }
    }
}
