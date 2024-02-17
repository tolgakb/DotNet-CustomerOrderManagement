using CustomerOrderManagement.Application.Common.Dto;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerOrderManagement.Application.Features.CustomerManagement.Commands.DeleteCustomer
{
    public record DeleteCustomerCommand(Guid Id) : IRequest<CustomerViewDto>
    {
    }
}
