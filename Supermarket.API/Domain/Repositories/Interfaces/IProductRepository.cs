using System.Collections.Generic;
using System.Threading.Tasks;
using Supermarket.API.Domain.Models;

namespace Supermarket.API.Domain.Repositories.Interfaces
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> ListAsync();
        Task<Product> GetAsync(int id);
        Task<Product> GetAsync(string productName);
    }
}