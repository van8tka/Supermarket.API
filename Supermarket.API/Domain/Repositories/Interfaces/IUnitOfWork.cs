using System.Threading.Tasks;

namespace Supermarket.API.Domain.Repositories.Interfaces
{
    public interface IUnitOfWork
    {
        Task CompleteAsync();
    }
}