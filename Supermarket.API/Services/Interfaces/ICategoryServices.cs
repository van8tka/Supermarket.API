using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Supermarket.API.Domain.Models;

namespace Supermarket.API.Services.Interfaces
{
    public interface ICategoryServices
    {
        Task<IEnumerable<Category>> ListAsync();
    }
}