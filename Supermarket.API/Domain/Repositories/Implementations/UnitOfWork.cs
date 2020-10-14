using System;
using System.Threading.Tasks;
using Supermarket.API.Domain.Repositories.Interfaces;
using Supermarket.API.Persistence.Contexts;

namespace Supermarket.API.Domain.Repositories.Implementations
{
    public class UnitOfWork:IUnitOfWork
    {
        private readonly AppDbContext _context;

        public UnitOfWork(AppDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}