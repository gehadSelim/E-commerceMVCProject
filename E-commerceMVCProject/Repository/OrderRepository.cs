using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using E_commerceMVCProject.Models;

namespace E_commerceMVCProject.Repository
{
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        public OrderRepository(EComEntity context) : base(context)
        {
        }

        public Order GetByUserId(string userId)
        {
            return GetByIdWithInclude(o => o.UserId == userId, o => o.OrderDetails);
        }
    }
}
