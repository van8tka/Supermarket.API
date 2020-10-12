using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Supermarket.API.Domain.Models;
using Supermarket.API.Domain.Repositories.Interfaces;
using Supermarket.API.Persistence.Contexts;

namespace Supermarket.API.Domain.Repositories.Implementations
{
    public class CategoryRepository:BaseRepository, ICategoryRepository
    {
        public CategoryRepository(AppDbContext context) : base(context)
        {
        }

        public IAsyncEnumerable<Category> ListAsync()
        {
            return  _context.Categories.AsAsyncEnumerable() ;
        }
    }
}
