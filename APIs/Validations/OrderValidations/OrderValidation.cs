using Applications.ViewModels;
using Domain.Enums;
using FluentValidation;

namespace APIs.Validations.OrderValidations
{
    public class OrderValidation : AbstractValidator<OrderViewModel>
    {
        public OrderValidation()
        {
            RuleFor(x => x.OrderDate).Empty();
            RuleFor(x => x.OrderStatus).IsInEnum();
            RuleFor(x => x.TotalPrice).IsInEnum();
            RuleFor(x => x.StudentId).NotEmpty();
        }
    }
}
