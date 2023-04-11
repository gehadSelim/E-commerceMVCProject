using AutoMapper;
using E_commerceMVCProject.Models;
using E_commerceMVCProject.Repository;
using E_commerceMVCProject.viewmodels;
using Microsoft.EntityFrameworkCore;

namespace E_commerceMVCProject.Services
{
    public class OrderService : IOrderService
    {

        private readonly IRepository<Order> _orderRepository;
        private readonly IMapper _mapper;

        public OrderService(IRepository<Order> orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        public void CreateOrder(OrderVM orderVm)
        {
            Order order = _mapper.Map<Order>(orderVm);
            _orderRepository.Insert(order);
        }

        public void DeleteOrder(int id)
        {
            Order order = _orderRepository.GetById(id);
            order.IsDeleted = true;
            _orderRepository.Update(order);

        }

        public List<OrderVM> GetAllOrders()
        {
            List<Order> orders = _orderRepository.GetAll().ToList();
            return _mapper.Map<List<OrderVM>>(orders);
        }

        public OrderVM GetOrderById(int id)
        {
            Order order = _orderRepository.GetAll().Include(o => o.OrderDetails).FirstOrDefault(o => o.Id == id);
            return _mapper.Map<OrderVM>(order);
        }

        public List<OrderVM> GetOrdersByDate(DateTime From, DateTime To)
        {
            List<Order> orders = _orderRepository.GetAll().Where(o => o.OrderDate >= From && o.OrderDate <= To).ToList();
            return _mapper.Map<List<OrderVM>>(orders);
        }

        public List<OrderVM> GetOrdersByUserId(string userId)
        {
            List<Order> orders = _orderRepository.GetAll().Where(o => o.UserId == userId).ToList();
            return _mapper.Map<List<OrderVM>>(orders);
        }
    }
}
