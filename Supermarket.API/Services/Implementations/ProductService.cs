﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Supermarket.API.Domain.Models;
using Supermarket.API.Domain.Repositories.Interfaces;
using Supermarket.API.Services.Interfaces;

namespace Supermarket.API.Services.Implementations
{
    public class ProductService:IProductService
    {
        private readonly IProductRepository _repository;

        public ProductService(IProductRepository repository)
        {
            _repository = repository;
        }
        public Task<IEnumerable<Product>> ListAsync()
        {
            return _repository.ListAsync();
        }

        public Task<Product> GetAsync(int id)
        {
            return _repository.GetAsync(id);
        }

        public Task<Product> GetByName(string productName)
        {
            return _repository.GetAsync(productName);
        }
    }
}