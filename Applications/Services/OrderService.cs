using Applications.Commons;
using Applications.Interfaces;
using Applications.ViewModels;
using AutoMapper;
using Domain.Entities;
using System.Net;

namespace Applications.Services
{
    public class OrderService : IOrderService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IClaimsServices _claimsServices;
        public OrderService(IUnitOfWork unitOfWork,
            IMapper mapper,
            IClaimsServices claimsServices)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _claimsServices = claimsServices;
        }


        public async Task<Response> GetAllOrder(int pageIndex = 0, int pageSize = 10)
        {
            var orderObj = await _unitOfWork.OrderRepository.ToPagination(pageIndex, pageSize);
            var result = _mapper.Map<Pagination<OrderViewModel>>(orderObj);
            if (!orderObj.Items.Any())
            {
                return new Response(HttpStatusCode.NotFound, "No Order Found");
            }
            return new Response(HttpStatusCode.OK, "Success", result);
        }

        public async Task<Response> GetOrderInfor(int id)
        {
            var orderObj = await _unitOfWork.OrderRepository.GetEntityByIdAsync(id);
            var result = _mapper.Map<OrderViewModel>(orderObj);
            if (orderObj is null)
            {
                return new Response(HttpStatusCode.NotFound, "No Order Found");
            }
            return new Response(HttpStatusCode.OK, "Success", result);
        }

        public async Task<Response> RemoveOrder(int id)
        {
            var orderObj = await _unitOfWork.OrderRepository.GetEntityByIdAsync(id);
            if (orderObj is not null)
            {

                _unitOfWork.OrderRepository.DeleteAsync(orderObj);
                var isSuccess = await _unitOfWork.SaveChangeAsync();
                if (isSuccess > 0)
                {
                    return new Response(HttpStatusCode.OK, "Success");
                }
            }
            return new Response(HttpStatusCode.BadRequest, "Fail");
        }

        public async Task<Response> UpdateOrder(int id, OrderViewModel orderViewModel)
        {
            var orderObj = await _unitOfWork.OrderRepository.GetEntityByIdAsync(id);
            if (orderObj is null)
                return new Response(HttpStatusCode.BadRequest, "Fail");

            _mapper.Map(orderViewModel, orderObj);
            _unitOfWork.OrderRepository.UpdateAsync(orderObj);
            await _unitOfWork.SaveChangeAsync();

            return new Response(HttpStatusCode.Accepted, "Success");
        }
        public async Task<Response> CreateOrder(OrderViewModel orderViewModel)
        {

            var orderObj = _mapper.Map<Order>(orderViewModel);
            await _unitOfWork.OrderRepository.CreateAsync(orderObj);
            var isSuccess = await _unitOfWork.SaveChangeAsync();
            if (isSuccess > 0)
            {
                return new Response(HttpStatusCode.Created, "Create success");
            }
            return new Response(HttpStatusCode.BadRequest, "Create fail");
        }
    }
}
