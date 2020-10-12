using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Supermarket.API.Domain.Models;

namespace Supermarket.API.Services.Interfaces
{
    public interface ICategoryServices
    {
        //fixme: using IAsyncEnumerable<> instead Task<IEnumerable<>
        IAsyncEnumerable<Category> ListAsync();
    }
}