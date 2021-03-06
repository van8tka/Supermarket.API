﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Supermarket.API.Domain.Models;

namespace Supermarket.API.Services.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> ListAsync();
        Task<Product> GetAsync(int id);
        Task<Product> GetByName(string productName);
    }
}