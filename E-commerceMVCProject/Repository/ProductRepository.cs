using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using E_commerceMVCProject.Models;
namespace E_commerceMVCProject.Repository
{
    public class ProductRepository : Repository<Product>, IProductrepository
    {
        public ProductRepository(EComEntity context) : base(context)
        {
        }

        public decimal GetTotalProfit(int id)
        {
            decimal totalProfit = 0;

            var product = GetByIdWithInclude(p => p.Id == id, p => p.OrderDetails);

            foreach (var orderDetail in product.OrderDetails)
            {
                totalProfit += orderDetail.Profit;
            }

            return totalProfit;
        }
    }
}
