using AutoMapper;
using CustomerOrderManagement.Application.Common.Dto;
using CustomerOrderManagement.Application.Features.CustomerManagement.Commands.CreateCustomer;
using CustomerOrderManagement.Application.Features.CustomerManagement.Commands.DeleteCustomer;
using CustomerOrderManagement.Application.Features.CustomerManagement.Commands.UpdateCustomer;
using CustomerOrderManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerOrderManagement.Application.Common.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Customer, CustomerViewDto>();
            CreateMap<Customer, CreateCustomerCommand>().ReverseMap();
            CreateMap<Customer, DeleteCustomerCommand>().ReverseMap();
            CreateMap<Customer, UpdateCustomerCommand>().ReverseMap();

        }
    }
}
