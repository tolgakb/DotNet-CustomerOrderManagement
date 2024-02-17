using AutoMapper;
using CustomerOrderManagement.Application.Common.Dto;
using CustomerOrderManagement.Application.Common.Interfaces;
using MediatR;
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

        public UpdateCustomerCommandHandler(ICustomerRepository customerRepository, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            
        }
        public async Task<CustomerViewDto> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
        {
            var customer = await _customerRepository.GetByIdAsync(request.Id);

            var updatedCustomer = _mapper.Map(request, customer);

            await _customerRepository.UpdateAsync(updatedCustomer);
            await _unitOfWork.SaveChangesAsync();

            var viewModel = _mapper.Map<CustomerViewDto>(updatedCustomer);

            return viewModel;
        }
    }
}
