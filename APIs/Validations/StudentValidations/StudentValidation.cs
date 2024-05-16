using Applications.ViewModels;
using FluentValidation;

namespace APIs.Validations.StudentValidations
{
    public class StudentValidation : AbstractValidator<StudentViewModel>
    {
        public StudentValidation()
        {
            //RuleFor(x => x.SelfDescription).NotEmpty();
            //RuleFor(x => x.TotalCourseLearned).NotEmpty();
        }
    }
}
