using CustomerOrderManagement.Application.Common.Dto;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerOrderManagement.Application.Features.OrderManagement.Queries.GetOrdersByCustomerId
{
    public record GetOrdersByCustomerIdQuery(Guid CustomerId) : IRequest<List<OrderViewDto>>;
    
}
