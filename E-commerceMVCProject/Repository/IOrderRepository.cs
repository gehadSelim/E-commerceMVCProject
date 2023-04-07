using E_commerceMVCProject.Models;

namespace E_commerceMVCProject.Repository
{
    public interface IOrderRepository : IRepository<Order>
    {
        Order GetByUserId(string userId);
    }
}
