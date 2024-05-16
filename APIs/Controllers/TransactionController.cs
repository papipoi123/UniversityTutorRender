using Applications.Commons;
using Applications.Interfaces;
using Applications.ViewModels;
using Domain.Enums;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace APIs.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        public readonly ITransactionService _transactionService;
        private readonly IValidator<TransactionViewModel> _validator;

        public TransactionController(ITransactionService transactionService, IValidator<TransactionViewModel> validator)
        {
            _transactionService = transactionService;
            _validator = validator;
        }

        // GET: api/Transaction
        [HttpGet]
        public async Task<Response> Get(int pageIndex = 0, int pageSize = 10)
        {
            var result = await _transactionService.GetAllTransaction(pageIndex, pageSize);
            return result;
        }
        // GET api/Transaction/5
        [HttpGet]
        public async Task<Response> GetById(int id)
        {
            Response result = await _transactionService.GetTransactionInfor(id);
            return result;
        }

        [HttpGet]
        public async Task<Response> GetByStatus([FromQuery] TransactionStatus status)
        {
            Response result = await _transactionService.GetTransactionByStatus(status);
            return result;
        }

        [HttpGet]
        public async Task<Response> GetByUserId([FromQuery] int id)
        {
            Response result = await _transactionService.GetTransactionByUserId(id);
            return result;
        }

        [HttpPut]
        public async Task<Response> AuthorizeTransaction([FromQuery] int id, TransactionStatus status)
        {
            Response result = await _transactionService.AuthorizeTransaction(id, status);
            return result;
        }

        // POST api/Transaction
        [HttpPost]
        public async Task<Response> Create(CreateTransactionViewModel model)
        {
            var result = await _transactionService.CreateTransaction(model);
            return result;
        }

        // PUT api/Transaction/5
        [HttpPut]
        public async Task<Response> Update(int id, TransactionViewModel model)
        {
            var result = await _transactionService.UpdateTransaction(id, model);
            return result;
        }

        // DELETE api/Transaction/5
        [HttpDelete]
        public async Task<Response> Delete(int id)
        {
            return await _transactionService.RemoveTransaction(id);
        }

    }
}
