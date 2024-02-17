using CustomerOrderManagement.Application.Common.Interfaces;
using CustomerOrderManagement.Persistence.DbContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerOrderManagement.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }

        public Task SaveChangesAsync()
        {
            return _context.SaveChangesAsync();
        }
    }
}
