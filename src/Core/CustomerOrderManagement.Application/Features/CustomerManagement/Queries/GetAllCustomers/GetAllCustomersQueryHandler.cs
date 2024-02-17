using AutoMapper;
using CustomerOrderManagement.Application.Common.Dto;
using CustomerOrderManagement.Application.Common.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerOrderManagement.Application.Features.CustomerManagement.Queries.GetAllCustomers
{
    public class GetAllCustomersQueryHandler : IRequestHandler<GetAllCustomersQuery, List<CustomerViewDto>>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;

        public GetAllCustomersQueryHandler(ICustomerRepository customerRepository, IMapper mapper)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
        }
        public async Task<List<CustomerViewDto>> Handle(GetAllCustomersQuery request, CancellationToken cancellationToken)
        {
            var customers = await _customerRepository.GetAllAsync();

            var viewModel = _mapper.Map<List<CustomerViewDto>>(customers);

            return viewModel;
        }
    }
}
