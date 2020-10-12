using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Supermarket.API.Persistence.Contexts;

namespace Supermarket.API.Domain.Repositories.Implementations
{
    public class BaseRepository
    {
        protected readonly AppDbContext _context;

        public BaseRepository(AppDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
    }
}
