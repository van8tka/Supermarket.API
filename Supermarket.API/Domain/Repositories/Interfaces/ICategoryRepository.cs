using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Supermarket.API.Domain.Models;

namespace Supermarket.API.Domain.Repositories.Interfaces
{
    public interface ICategoryRepository
    {
        IAsyncEnumerable<Category> ListAsync();
    }
}