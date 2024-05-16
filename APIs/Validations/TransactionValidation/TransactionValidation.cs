using Applications.ViewModels;
using FluentValidation;
using System.Transactions;

namespace APIs.Validations.TransactionValidations
{
    public class TransactionValidation : AbstractValidator<TransactionViewModel>
    {
        public TransactionValidation()
        {
            RuleFor(x => x.TransactionStatus).NotEmpty().IsInEnum();
            RuleFor(x => x.AmountTransaction).NotEmpty().GreaterThan(10000);
            RuleFor(x => x.WalletId).NotEmpty();
        }
    }
}
