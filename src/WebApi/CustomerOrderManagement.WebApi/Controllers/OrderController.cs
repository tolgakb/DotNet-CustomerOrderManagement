using CustomerOrderManagement.Application.Features.OrderManagement.Commands.CreateOrder;
using CustomerOrderManagement.Application.Features.OrderManagement.Queries.GetAllOrders;
using CustomerOrderManagement.Application.Features.OrderManagement.Queries.GetOrdersByCustomerId;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CustomerOrderManagement.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrderController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("customer/{customerId}")]
        public async Task<IActionResult> GetOrdersBCustomerId(Guid customerId)
        {
            var query = new GetOrdersByCustomerIdQuery(customerId);
            var result = await _mediator.Send(query);

            return Ok(result);
        }

        [HttpGet("customer")]
        public async Task<IActionResult> GetAllOrders() 
        {
            var query = new GetAllOrdersQuery();
            var result = await _mediator.Send(query);   

            return Ok(result);
        }
    }
}
