using E_commerceMVCProject.Models;
using E_commerceMVCProject.Repository;
using Microsoft.EntityFrameworkCore;

namespace E_commerceMVCProject.Services
{
    public class OrderService : IOrderService
    {

        private readonly IRepository<Order> _orderRepository;

        public OrderService(IRepository<Order> orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public void CreateOrder(Order order)
        {
            _orderRepository.Insert(order);
        }

        public void DeleteOrder(int id)
        {
            Order order = _orderRepository.GetById(id);
            order.IsDeleted = true;
            _orderRepository.Update(order);

        }

        public List<Order> GetAllOrders()
        {
            return _orderRepository.GetAll().ToList();
        }

        public Order GetOrderById(int id)
        {
            return _orderRepository.GetAll().Include(o => o.OrderDetails).FirstOrDefault(o => o.Id == id);

        }

        public List<Order> GetOrdersByDate(DateTime From, DateTime To)
        {
            return _orderRepository.GetAll().Where(o => o.OrderDate >= From && o.OrderDate <= To).ToList();
        }

        public List<Order> GetOrdersByUserId(string userId)
        {
            return _orderRepository.GetAll().Where(o => o.UserId == userId).ToList();
        }
    }
}
