using E_commerceMVCProject.Models;
using E_commerceMVCProject.viewmodels;

namespace E_commerceMVCProject.Services
{
    public interface IOrderService
    {
        List<OrderVM> GetAllOrders();
        List<OrderVM> GetOrdersByUserId(string userId);
        List<OrderVM> GetOrdersByDate(DateTime From, DateTime To);
        OrderVM GetOrderById(int id);
        void CreateOrder(OrderVM orderVm);
        void DeleteOrder(int id);
    }
}
