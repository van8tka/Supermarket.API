﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Supermarket.API.Domain.Models;
using Supermarket.API.Domain.Repositories.Interfaces;
using Supermarket.API.Persistence.Contexts;

namespace Supermarket.API.Domain.Repositories.Implementations
{
    public class ProductRepository: BaseRepository,IProductRepository
    {
        public ProductRepository(AppDbContext context):base(context)
        { }
        public async Task<IEnumerable<Product>> ListAsync()
        {
            return await _context.Products.Include(p=>p.Category).ToListAsync();
        }
    }
}