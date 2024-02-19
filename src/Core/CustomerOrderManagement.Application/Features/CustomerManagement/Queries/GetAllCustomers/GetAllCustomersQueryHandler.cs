using AutoMapper;
using CustomerOrderManagement.Application.Common.Dto;
using CustomerOrderManagement.Application.Common.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;
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
        private readonly ILogger<GetAllCustomersQueryHandler> _logger;

        public GetAllCustomersQueryHandler(ICustomerRepository customerRepository, IMapper mapper, ILogger<GetAllCustomersQueryHandler> logger)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
            _logger = logger;
        }
        public async Task<List<CustomerViewDto>> Handle(GetAllCustomersQuery request, CancellationToken cancellationToken)
        {
            var customers = await _customerRepository.GetAllAsync();

            if (customers == null) 
            {
                _logger.LogError("GetAllCustomersQueryHandler returned null value.");
            }

            var viewModel = _mapper.Map<List<CustomerViewDto>>(customers);

            return viewModel;
        }
    }
}
