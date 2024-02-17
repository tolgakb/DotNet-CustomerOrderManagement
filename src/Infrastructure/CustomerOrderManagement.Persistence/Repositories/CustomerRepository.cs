using CustomerOrderManagement.Application.Common.Interfaces;
using CustomerOrderManagement.Domain.Entities;
using CustomerOrderManagement.Persistence.DbContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerOrderManagement.Persistence.Repositories
{
    public class CustomerRepository : GenericRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
