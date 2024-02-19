using CustomerOrderManagement.Application.Common.Interfaces;
using CustomerOrderManagement.Domain.Entities;
using CustomerOrderManagement.Persistence.DbContexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace CustomerOrderManagement.Persistence.Repositories
{
    public class OrderRepository : GenericRepository<Order>, IOrderRepository
    {
        public OrderRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<List<Order>> GetOrdersByCustomerIdAsync(Guid customerId)
        {
            return await _context.Orders.Where(o => o.CustomerId == customerId).ToListAsync();
        }

        public async Task<List<Order>> GetOrdersByCustomerIdWithOrderAsync(Guid customerId)
        {
            var orders = await GetOrdersByCustomerIdAsync(customerId);
            var sortedOrders = orders.OrderByDescending(o => o.CreatedDate).ToList();

            return sortedOrders;
        }
    }
}
