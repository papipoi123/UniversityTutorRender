using Applications.Commons;
using Applications.ViewModels;

namespace Applications.Interfaces
{
    public interface IOrderService
    {
        Task<Response> CreateOrder(OrderViewModel orderViewModel);
        Task<Response> GetAllOrder(int pageIndex = 0, int pageSize = 10);
        Task<Response> GetOrderInfor(int id);
        Task<Response> RemoveOrder(int id);
        Task<Response> UpdateOrder(int id, OrderViewModel orderViewModel);
    }
}