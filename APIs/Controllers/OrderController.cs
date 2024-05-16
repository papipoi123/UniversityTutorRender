using Applications.Commons;
using Applications.Interfaces;
using Applications.ViewModels;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace APIs.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        public readonly IOrderService _orderService;
        private readonly IValidator<OrderViewModel> _validator;

        public OrderController(IOrderService orderService, IValidator<OrderViewModel> validator)
        {
            _orderService = orderService;
            _validator = validator;
        }

        // GET: api/Order
        [HttpGet]
        public async Task<Response> Get(int pageIndex = 0, int pageSize = 10)
        {
            var result = await _orderService.GetAllOrder(pageIndex, pageSize);
            return result;
        }
        // GET api/Order/5
        [HttpGet]
        public async Task<Response> GetById(int id)
        {
            Response result = await _orderService.GetOrderInfor(id);
            return result;
        }

        // POST api/Order
        [HttpPost]
        public async Task<Response> Create(OrderViewModel model)
        {
            var result = await _orderService.CreateOrder(model);
            return result;
        }

        // PUT api/Order/5
        [HttpPut]
        public async Task<Response> Update(int id, OrderViewModel model)
        {
            var result = await _orderService.UpdateOrder(id, model);
            return result;
        }

        // DELETE api/Order/5
        [HttpDelete]
        public async Task<Response> Delete(int id)
        {
            return await _orderService.RemoveOrder(id);
        }
    }
}
