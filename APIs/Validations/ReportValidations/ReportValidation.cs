using Applications.ViewModels;
using FluentValidation;

namespace APIs.Validations.ReportValidations
{
    public class ReportValidation : AbstractValidator<ReportViewModel>
    {
        public ReportValidation()
        {
            RuleFor(x => x.ReportName).NotEmpty();
            RuleFor(x => x.ReportContent).NotEmpty();
            RuleFor(x => x.CreationDate).NotEmpty();
            RuleFor(x => x.UserId).NotEmpty();
        }
    }
}
