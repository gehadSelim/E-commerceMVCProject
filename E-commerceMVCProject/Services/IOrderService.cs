using E_commerceMVCProject.Models;

namespace E_commerceMVCProject.Services
{
    public interface IOrderService
    {
        List<Order> GetAllOrders();
        List<Order> GetOrdersByUserId(string userId);
        List<Order> GetOrdersByDate(DateTime From, DateTime To);
        Order GetOrderById(int id);
        void CreateOrder(Order order);
        void DeleteOrder(int id);
    }
}
