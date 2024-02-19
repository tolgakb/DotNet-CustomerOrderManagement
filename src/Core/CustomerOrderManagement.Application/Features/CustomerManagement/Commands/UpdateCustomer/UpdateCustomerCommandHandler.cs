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

namespace CustomerOrderManagement.Application.Features.CustomerManagement.Commands.UpdateCustomer
{
    public class UpdateCustomerCommandHandler : IRequestHandler<UpdateCustomerCommand, CustomerViewDto>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<UpdateCustomerCommandHandler> _logger;

        public UpdateCustomerCommandHandler(ICustomerRepository customerRepository, IMapper mapper, IUnitOfWork unitOfWork, ILogger<UpdateCustomerCommandHandler> logger)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _logger = logger;
        }
        public async Task<CustomerViewDto> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
        {
            var validationResult = await new UpdateCustomerCommandValidator().ValidateAsync(request, cancellationToken);

            if(!validationResult.IsValid)
            {
                var errors = validationResult.Errors.Select(error => error.ErrorMessage).ToList();
                _logger.LogError("Validation failed while updating customer. {errors}", errors);
            }

            var customer = await _customerRepository.GetByIdAsync(request.Id);

            if(customer == null)
            {
                _logger.LogError("Customer with Id {request.Id} is not exist ", request.Id);
                throw new CustomerNotFoundException(request.Id);
            }

            customer.UpdatedDate = DateTime.UtcNow;

            var updatedCustomer = _mapper.Map(request, customer);

            await _customerRepository.UpdateAsync(updatedCustomer);
            await _unitOfWork.SaveChangesAsync();

            var viewModel = _mapper.Map<CustomerViewDto>(updatedCustomer);

            return viewModel;
        }
    }
}
