using Domain.Base;
using Domain.Entities;
using Domain.Enums;
using System.Text.Json.Serialization;

namespace Applications.ViewModels
{
    public class TransactionViewModel
    {
        public TransactionStatus TransactionStatus { get; set; }
        public decimal AmountTransaction { get; set; }
        public string? TransactionDescription { get; set; }
        public int WalletId { get; set; }
    }
    public class GetTransactionViewModel : TransactionViewModel
    {
        public int Id { get; set; }
    }

    public class CreateTransactionViewModel
    {
        public int Id { get; set; }
        public TransactionStatus TransactionStatus { get; set; }
        public TransactionType TransactionType { get; set; }
        public DateTime? CreateAt { get; set; } = DateTime.UtcNow;
        public decimal AmountTransaction { get; set; }
        public string TransactionDescription { get; set; }
        public int WalletId { get; set; }
    }
}