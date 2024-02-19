using AutoMapper;
using CustomerOrderManagement.Application.Common.Dto;
using CustomerOrderManagement.Application.Common.Interfaces;
using CustomerOrderManagement.Domain.Exceptions;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerOrderManagement.Application.Features.CustomerManagement.Queries.GetCustomerById
{
    public class GetCustomerByIdQueryHandler : IRequestHandler<GetCustomerByIdQuery, CustomerViewDto>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<GetCustomerByIdQueryHandler> _logger;

        public GetCustomerByIdQueryHandler(ICustomerRepository customerRepository, IMapper mapper, ILogger<GetCustomerByIdQueryHandler> logger)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
            _logger = logger;
        }
        public async Task<CustomerViewDto> Handle(GetCustomerByIdQuery request, CancellationToken cancellationToken)
        {
            var customer = await _customerRepository.GetByIdAsync(request.Id);

            if (customer == null) 
            {
                _logger.LogError("Customer with id : {id} could not found", request.Id);
                throw new CustomerNotFoundException(request.Id);
            }

            var viewModel = _mapper.Map<CustomerViewDto>(customer);

            return viewModel;
        }
    }
}
