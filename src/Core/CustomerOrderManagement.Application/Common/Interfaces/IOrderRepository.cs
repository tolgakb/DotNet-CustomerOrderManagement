using CustomerOrderManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerOrderManagement.Application.Common.Interfaces
{
    public interface IOrderRepository : IGenericRepositoryAsync<Order>
    {
        Task<List<Order>> GetOrdersByCustomerIdAsync(Guid customerId);
        Task<List<Order>> GetOrdersByCustomerIdWithOrderAsync(Guid customerId);
    }
}
