using System.Collections.Generic;
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
    }
}