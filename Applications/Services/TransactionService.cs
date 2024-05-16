using Applications.Commons;
using Applications.Interfaces;
using Applications.ViewModels;
using AutoMapper;
using Domain.Entities;
using Domain.Enums;
using System.Net;

namespace Applications.Services
{
    public class TransactionService : ITransactionService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IClaimsServices _claimsServices;
        public TransactionService(IUnitOfWork unitOfWork,
            IMapper mapper,
            IClaimsServices claimsServices)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _claimsServices = claimsServices;
        }

        public async Task<Response> GetAllTransaction(int pageIndex = 0, int pageSize = 10)
        {
            var transactionObj = await _unitOfWork.TransactionRepository.ToPagination(pageIndex, pageSize);
            var result = _mapper.Map<Pagination<TransactionViewModel>>(transactionObj);
            if (!transactionObj.Items.Any())
            {
                return new Response(HttpStatusCode.NotFound, "No Transaction Found");
            }
            return new Response(HttpStatusCode.OK, "Success", result);
        }

        public async Task<Response> GetTransactionInfor(int id)
        {
            var transactionObj = await _unitOfWork.TransactionRepository.GetEntityByIdAsync(id);
            var result = _mapper.Map<Pagination<TransactionViewModel>>(transactionObj);
            if (transactionObj is null)
            {
                return new Response(HttpStatusCode.NotFound, "No Transaction Found");
            }
            return new Response(HttpStatusCode.OK, "Success", result);
        }

        public async Task<Response> RemoveTransaction(int id)
        {
            var transactionObj = await _unitOfWork.TransactionRepository.GetEntityByIdAsync(id);
            if (transactionObj is not null)
            {

                _unitOfWork.TransactionRepository.DeleteAsync(transactionObj);
                var isSuccess = await _unitOfWork.SaveChangeAsync();
                if (isSuccess > 0)
                {
                    return new Response(HttpStatusCode.OK, "Success");
                }
            }
            return new Response(HttpStatusCode.BadRequest, "Fail");
        }

        public async Task<Response> UpdateTransaction(int id, TransactionViewModel transactionViewModel)
        {
            //validate data

            var transactionObj = await _unitOfWork.TransactionRepository.GetEntityByIdAsync(id);
            if (transactionObj is null)
                return new Response(HttpStatusCode.BadRequest, "Fail");

            _mapper.Map(transactionViewModel, transactionObj);
            _unitOfWork.TransactionRepository.UpdateAsync(transactionObj);
            await _unitOfWork.SaveChangeAsync();

            return new Response(HttpStatusCode.Accepted, "Success");
        }

        public async Task<Response> AuthorizeTransaction(int id, TransactionStatus status)
        {
            //validate data

            var transactionObj = await _unitOfWork.TransactionRepository.GetEntityByIdAsync(id);
            var Walletobj = await _unitOfWork.WalletRepository.GetEntityByIdAsync(transactionObj.WalletId);
            if (transactionObj is null)
                return new Response(HttpStatusCode.BadRequest, "Fail");
            if (status == Domain.Enums.TransactionStatus.Complete &&  transactionObj.TransactionType == Domain.Enums.TransactionType.withdraw)
            {
                transactionObj.TransactionStatus = Domain.Enums.TransactionStatus.Complete;
                Walletobj.WalletAmount = Walletobj.WalletAmount - transactionObj.AmountTransaction;
                _unitOfWork.WalletRepository.UpdateAsync(Walletobj);
                await _unitOfWork.SaveChangeAsync();
            }
            else if (status == Domain.Enums.TransactionStatus.Complete && transactionObj.TransactionType == Domain.Enums.TransactionType.recharge)
            {
                transactionObj.TransactionStatus = Domain.Enums.TransactionStatus.Complete;
                Walletobj.WalletAmount = Walletobj.WalletAmount + transactionObj.AmountTransaction;
                _unitOfWork.WalletRepository.UpdateAsync(Walletobj);
                await _unitOfWork.SaveChangeAsync();
            } else if (status == Domain.Enums.TransactionStatus.Failed)
            {
                transactionObj.TransactionStatus = Domain.Enums.TransactionStatus.Failed;
            }
            _unitOfWork.TransactionRepository.UpdateAsync(transactionObj);
            await _unitOfWork.SaveChangeAsync();

            return new Response(HttpStatusCode.Accepted, "Success");
        }

        public async Task<Response> CreateTransaction(CreateTransactionViewModel transactionViewModel)
        {
            var Walletobj = await _unitOfWork.WalletRepository.GetEntityByIdAsync(transactionViewModel.WalletId);
            if (transactionViewModel.TransactionType == Domain.Enums.TransactionType.withdraw && transactionViewModel.AmountTransaction >= Walletobj.WalletAmount)
            {
                return new Response(HttpStatusCode.BadRequest, "Your Wallet Amount Not Enough To Withdraw");
            }
            transactionViewModel.TransactionStatus = Domain.Enums.TransactionStatus.WaitingForConFirm;
            var transactionObj = _mapper.Map<Transaction>(transactionViewModel);
            await _unitOfWork.TransactionRepository.CreateAsync(transactionObj);
            var isSuccess = await _unitOfWork.SaveChangeAsync();
            if (isSuccess > 0)
            {
                return new Response(HttpStatusCode.Created, "Create success");
            }
            return new Response(HttpStatusCode.BadRequest, "Create fail");
        }

        public async Task<Response> GetTransactionByStatus(TransactionStatus status, int pageIndex = 0, int pageSize = 10)
        {
            var transactionObj = await _unitOfWork.TransactionRepository.GetByTransactionStatus(status, pageIndex, pageSize);
            var result = _mapper.Map<Pagination<TransactionViewModel>>(transactionObj);
            if (!transactionObj.Items.Any())
            {
                return new Response(HttpStatusCode.NotFound, "No Transaction Found");
            }
            return new Response(HttpStatusCode.OK, "Success", result);
        }

        public async Task<Response> GetTransactionByUserId(int id, int pageIndex = 0, int pageSize = 10)
        {
            var transactionObj = await _unitOfWork.TransactionRepository.GetByTransactionByUserId(id, pageIndex, pageSize);
            var result = _mapper.Map<Pagination<TransactionViewModel>>(transactionObj);
            if (!transactionObj.Items.Any())
            {
                return new Response(HttpStatusCode.NotFound, "No Transaction Found");
            }
            return new Response(HttpStatusCode.OK, "Success", result);
        }
    }
}
