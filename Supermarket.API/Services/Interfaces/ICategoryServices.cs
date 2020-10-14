using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Supermarket.API.Domain.Communication;
using Supermarket.API.Domain.Models;
using Supermarket.API.Resources;

namespace Supermarket.API.Services.Interfaces
{
    public interface ICategoryServices
    {
        Task<IEnumerable<Category>> ListAsync();
        Task<CategoryResponse> SaveAsync(Category category);
        Task<CategoryResponse> UpdateAsync(int id, Category category);
        Task<CategoryResponse> DeleteAsync(int id);
    }
}