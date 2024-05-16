using Applications.Commons;
using Applications.ViewModels;
using Domain.Enums;

namespace Applications.Interfaces
{
    public interface ITransactionService
    {
        Task<Response> CreateTransaction(CreateTransactionViewModel transactionViewModel);
        Task<Response> GetAllTransaction(int pageIndex = 0, int pageSize = 10);
        Task<Response> GetTransactionInfor(int id);
        Task<Response> RemoveTransaction(int id);
        Task<Response> UpdateTransaction(int id, TransactionViewModel transactionViewModel);
        Task<Response> AuthorizeTransaction(int id, TransactionStatus status);
        Task<Response> GetTransactionByStatus(TransactionStatus status, int pageIndex = 0, int pageSize = 10);
        Task<Response> GetTransactionByUserId(int id, int pageIndex = 0, int pageSize = 10);
    }
}