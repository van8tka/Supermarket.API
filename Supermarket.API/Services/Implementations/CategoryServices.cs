using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Supermarket.API.Domain.Models;
using Supermarket.API.Domain.Repositories.Interfaces;
using Supermarket.API.Services.Interfaces;

namespace Supermarket.API.Services.Implementations
{
    public class CategoryServices:ICategoryServices
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryServices(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository ?? throw new ArgumentNullException(nameof(categoryRepository));
        }

        public IAsyncEnumerable<Category> ListAsync()
        {
            return _categoryRepository.ListAsync();
        }
    }
}