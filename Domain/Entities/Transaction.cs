using Domain.Base;
using Domain.Enums;

namespace Domain.Entities
{
    public class Transaction : BaseEntity
    {
        public TransactionStatus TransactionStatus { get; set; }
        public TransactionType TransactionType { get; set; }
        public DateTime? CreateAt { get; set; }
        public decimal AmountTransaction { get; set; }
        public string TransactionDescription { get; set; }
        public int WalletId { get; set; }
        public Wallet? Wallet { get; set; }
    }
}
