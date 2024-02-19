using AutoMapper;
using CustomerOrderManagement.Application.Common.Dto;
using CustomerOrderManagement.Application.Common.Interfaces;
using CustomerOrderManagement.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerOrderManagement.Application.Features.CustomerManagement.Commands.CreateCustomer
{
    public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, CustomerViewDto>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<CreateCustomerCommandHandler> _logger;

        public CreateCustomerCommandHandler(ICustomerRepository customerRepository, IMapper mapper, IUnitOfWork unitOfWork, ILogger<CreateCustomerCommandHandler> logger)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _logger = logger;
        }
        public async Task<CustomerViewDto> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            var validationResult = await new CreateCustomerCommandValidator().ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid) 
            {
                var errors = validationResult.Errors.Select(error => error.ErrorMessage).ToList();
                _logger.LogError("Validation failed while creating customer. {errors}", errors);
            }

            var customer = _mapper.Map<Customer>(request);

            await _customerRepository.AddAsync(customer);
            await _unitOfWork.SaveChangesAsync();

            var viewModel = _mapper.Map<CustomerViewDto>(customer);

            return viewModel;
        }
    }
}
