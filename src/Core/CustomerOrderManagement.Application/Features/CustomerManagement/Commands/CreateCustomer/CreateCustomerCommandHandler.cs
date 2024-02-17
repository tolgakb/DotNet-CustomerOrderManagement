using AutoMapper;
using CustomerOrderManagement.Application.Common.Dto;
using CustomerOrderManagement.Application.Common.Interfaces;
using CustomerOrderManagement.Domain.Entities;
using MediatR;
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

        public CreateCustomerCommandHandler(ICustomerRepository customerRepository, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            
        }
        public async Task<CustomerViewDto> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            var customer = _mapper.Map<Customer>(request);

            await _customerRepository.AddAsync(customer);
            await _unitOfWork.SaveChangesAsync();

            var viewModel = _mapper.Map<CustomerViewDto>(customer);

            return viewModel;
        }
    }
}
