using AutoMapper;
using E_commerceMVCProject.Models;
using E_commerceMVCProject.Repository;
using E_commerceMVCProject.viewmodels;
using MailKit.Search;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace E_commerceMVCProject.Services
{
    public class ProductService : IProductService
    {
        private readonly IRepository<Product> _productRepository;
        private readonly IRepository<OrderDetail> _orderDetailRepository;
        private readonly IMapper _mapper;

        public ProductService(IRepository<Product> productRepository, IRepository<OrderDetail> orderDetailRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _orderDetailRepository = orderDetailRepository;
            _mapper = mapper;
        }

        public List<ProductVM> GetAllProducts()
        {
            List<Product> products = _productRepository.GetAll().Include(p => p.Images).ToList().Where(product => product.StockCount != 0).ToList();
            return _mapper.Map<List<ProductVM>>(products);
        }
        public int? GetLastId()
        {
            return GetAllProducts().LastOrDefault().Id;
        }
        public ProductVM? GetProductById(int id)
        {
            Product? product = _productRepository.GetAll().Include(p => p.Images).Include(p=>p.ProductBrand).Include(p=>p.ProductCategory).FirstOrDefault(p => p.Id == id);
            return _mapper.Map<ProductVM>(product);
        }
        public ProductVM GetProductByIDNoTracking(int id)
        {
            Product? product = _productRepository.GetAll().Include(p => p.Images).Where(product => product.Id == id).AsNoTracking().ToList().FirstOrDefault();
            return _mapper.Map<ProductVM>(product);

        }
        public ProductVM AddProduct(ProductVM productVM)
        {
            Product product = _mapper.Map<Product>(productVM);
            _productRepository.Insert(product);
            return _mapper.Map<ProductVM>(product);
        }

        public ProductVM UpdateProduct(ProductVM productVM)
        {
            Product product = _mapper.Map<Product>(productVM);
            _productRepository.Update(product);
            return _mapper.Map<ProductVM>(product);
        }

        public void DeleteProduct(int id)
        {
            _productRepository.Delete(id);
        }

        public List<ProductVM> GetBestSellingProducts()
        {
            var topSellingProducts = _orderDetailRepository.GetAll()
                    .GroupBy(d => d.ProductId)
                    .Select(g => new { ProductId = g.Key, Quantity = g.Sum(d => d.Quantity) })
                    .OrderByDescending(p => p.Quantity)
                    .Take(10)
                    .ToList();

            List<Product> products = _productRepository.GetAll()
                    .Where(p => topSellingProducts.Any(tp => tp.ProductId == p.Id))
                    .ToList();

            return _mapper.Map<List<ProductVM>>(products);
        }

        public List<ProductVM> GetBestProfitProducts()
        {
            var topProfitProducts = _orderDetailRepository.GetAll()
                    .GroupBy(d => d.ProductId)
                    .Select(g => new { ProductId = g.Key, Profit = g.Sum(d => d.Profit) })
                    .OrderByDescending(p => p.Profit)
                    .Take(10)
                    .ToList();

            List<Product> products = _productRepository.GetAll()
                    .Where(p => topProfitProducts.Any(tp => tp.ProductId == p.Id))
                    .ToList();

            return _mapper.Map<List<ProductVM>>(products);
        }

        public List<ProductVM> GetByCategoryId(int CategoryId)
        {
            List<Product> products = _productRepository.GetAll().Include(p => p.Images).Where(p => p.CategoryId == CategoryId).ToList();
            return _mapper.Map<List<ProductVM>>(products);
        }
        public List<ProductVM> GetByBrandId(int BrandId)
        {
            List<Product> products = _productRepository.GetAll().Include(p => p.Images).Where(p => p.BrandId == BrandId).ToList();
            return _mapper.Map<List<ProductVM>>(products);
        }
        public List<ProductVM> FilterByName(string searchName)
        {
            List<Product> products = _productRepository.GetAll().Include(p => p.Images).Where(p => p.Name.Contains(searchName)).ToList();
            return _mapper.Map<List<ProductVM>>(products);
        }
        public List<ProductVM> FilterByPrice(int low, int high)
        {
            List<Product> products = _productRepository.GetAll().Include(p => p.Images).Where(p => (p.SellingPrice >= low && p.SellingPrice <= high)).ToList();
            return _mapper.Map<List<ProductVM>>(products);
        }

        public List<List<ProductVM>> FilterbyBrands(List<int> BrandsIds)
        {
            List<List<ProductVM>> products = new List<List<ProductVM>>();
            if (BrandsIds.Any())
            {
                foreach (int brandId in BrandsIds)
                {
                    products.Add(GetByBrandId(brandId).ToList());
                }
            }
            return products;
        }
    }
}

