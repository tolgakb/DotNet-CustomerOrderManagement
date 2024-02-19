using AutoMapper;
using CustomerOrderManagement.Application.Common.Dto;
using CustomerOrderManagement.Application.Common.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerOrderManagement.Application.Features.OrderManagement.Queries.GetAllOrders
{
    public class GetAllOrdersQueryHandler : IRequest<List<OrderViewDto>>
    {
        private readonly IOrderRepository _orderReposRepository;
        private readonly IMapper _mapper;

        public GetAllOrdersQueryHandler(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderReposRepository = orderRepository;
            _mapper = mapper;
        }
        public async Task<List<OrderViewDto>> Handle(GetAllOrdersQueryHandler request, CancellationToken cancellationToken)
        {
            var orders = await _orderReposRepository.GetAllAsync();

            var viewModel = _mapper.Map<List<OrderViewDto>>(orders);

            return viewModel;
        }
    }
}
