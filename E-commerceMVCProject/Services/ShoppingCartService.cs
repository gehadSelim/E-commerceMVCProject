﻿using AutoMapper;
using E_commerceMVCProject.Models;
using E_commerceMVCProject.Repository;
using E_commerceMVCProject.viewmodels;
using Microsoft.EntityFrameworkCore;

namespace E_commerceMVCProject.Services
{
    public class ShoppingCartService : IShoppingCartService
    {
        private readonly IRepository<ShoppingCart> _cartRepository;
        private readonly IMapper _mapper;
        public ShoppingCartService(IRepository<ShoppingCart> cartRepository,IMapper mapper)
        {
            _cartRepository = cartRepository;
            _mapper = mapper;
        }
        public void AddCart(ShoppingCartVM cartVm)
        {
            ShoppingCart cart = _mapper.Map<ShoppingCart>(cartVm);
            _cartRepository.Insert(cart);
        }

        public void DeletefromCart(int id)
        {
            _cartRepository.Delete(id);
        }

        public ShoppingCartVM GetCartById(int id)
        {
            ShoppingCart cart = _cartRepository.GetAll().Include(c => c.Product).AsNoTracking().FirstOrDefault(c => c.Id == id);
            return _mapper.Map<ShoppingCartVM>(cart);
        }

        public ShoppingCartVM GetCartByProductandUserId(int productId, string userId)
        {
            ShoppingCart cart = _cartRepository.GetAll().Include(c => c.Product).ThenInclude(p=>p.Images).AsNoTracking().FirstOrDefault(c => c.ProductId == productId && c.UserId == userId);
            return _mapper.Map<ShoppingCartVM>(cart);
        }

        public List<ShoppingCartVM> GetCartByUserId(string userId)
        {
            List<ShoppingCart> shoppingCarts = _cartRepository.GetAll().Include(c => c.Product).ThenInclude(p => p.Images).Where(c => c.UserId == userId).AsNoTracking().ToList();
            return _mapper.Map<List<ShoppingCartVM>>(shoppingCarts);
        }

        public void UpdateCart(ShoppingCartVM cartVm)
        {
            ShoppingCart cart = _mapper.Map<ShoppingCart>(cartVm);
            _cartRepository.Update(cart);
        }
    }
}
