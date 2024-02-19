using CustomerOrderManagement.Application.Common.Dto;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerOrderManagement.Application.Features.OrderManagement.Commands.CreateOrder
{
    public class CreateOrderCommand : IRequest<OrderViewDto>
    {
        public String Name { get; set; }

        public String Description { get; set; }

        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }

    }
}
