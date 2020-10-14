using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Supermarket.API.Domain.Communication;
using Supermarket.API.Domain.Models;
using Supermarket.API.Domain.Repositories.Interfaces;
using Supermarket.API.Services.Interfaces;

namespace Supermarket.API.Services.Implementations
{
    public class CategoryServices:ICategoryServices
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IUnitOfWork _unitOfWork;
        public CategoryServices(ICategoryRepository categoryRepository, IUnitOfWork unitOfWork)
        {
            _categoryRepository = categoryRepository ?? throw new ArgumentNullException(nameof(categoryRepository));
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public Task<IEnumerable<Category>> ListAsync()
        {
            return _categoryRepository.ListAsync();
        }

        public async Task<SaveCategoryResponse> SaveAsync(Category category)
        {
            try
            {
                await _categoryRepository.AddAsync(category);
                await _unitOfWork.CompleteAsync();
                return new SaveCategoryResponse(category);
            }
            catch (Exception er)
            {
                return new SaveCategoryResponse($"An error occurred when saving the category: {er.Message}");
            }
        }
    }
}