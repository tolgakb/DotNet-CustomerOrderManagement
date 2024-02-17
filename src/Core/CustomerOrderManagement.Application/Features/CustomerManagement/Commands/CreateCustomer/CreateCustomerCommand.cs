using CustomerOrderManagement.Application.Common.Dto;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerOrderManagement.Application.Features.CustomerManagement.Commands.CreateCustomer
{
    public class CreateCustomerCommand : IRequest<CustomerViewDto>
    {
        public String? FirstName { get; set; }

        public String? LastName { get; set; }

        public String? Email { get; set; }

        public String? Phone { get; set; }

        public String? Address { get; set; }

        public String? City { get; set; }

        public String? Country { get; set; }
    }
}
