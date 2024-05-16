using Domain.Base;

namespace Domain.Entities
{
    public class Wallet : BaseEntity
    {
        public decimal WalletAmount { get; set; }
        public User? User { get; set; }
        public List<Transaction>? Transactions { get; set; }
    }
}
