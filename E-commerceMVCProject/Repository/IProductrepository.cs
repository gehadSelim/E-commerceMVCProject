using E_commerceMVCProject.Models;
namespace E_commerceMVCProject.Repository
{
    public interface IProductrepository : IRepository<Product>
    {
        decimal GetTotalProfit(int id);
    }
}
