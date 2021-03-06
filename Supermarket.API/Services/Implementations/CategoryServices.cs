﻿using System;
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

        public async Task<CategoryResponse> SaveAsync(Category category)
        {
            try
            {
                await _categoryRepository.AddAsync(category);
                await _unitOfWork.CompleteAsync();
                return new CategoryResponse(category);
            }
            catch (Exception er)
            {
                return new CategoryResponse($"An error occurred when saving the category: {er.Message}");
            }
        }

        public async Task<CategoryResponse> UpdateAsync(int id, Category category)
        {
            try
            {
                var existingCategory = await _categoryRepository.FindByIdAsync(id);
                if(existingCategory == null)
                    return new CategoryResponse($"Category with id={id} not found");
                existingCategory.Name = category.Name;
                _categoryRepository.Update(existingCategory);
                await _unitOfWork.CompleteAsync();
                return new CategoryResponse(existingCategory);
            }
            catch (Exception er)
            {
                return new CategoryResponse($"An error occurred when updating the category: {er.Message}");
            }
        }

        public async Task<CategoryResponse> DeleteAsync(int id)
        {
            try
            {
                var existingCategory = await _categoryRepository.FindByIdAsync(id);
                if (existingCategory == null)
                    return new CategoryResponse($"Category with id={id} not found");
                _categoryRepository.Remove(existingCategory);
                await _unitOfWork.CompleteAsync();
                return new CategoryResponse(existingCategory);
            }
            catch (Exception er)
            {
                return new CategoryResponse($"An error occurred when deleting the category: {er.Message}");
            }
        }
    }
}