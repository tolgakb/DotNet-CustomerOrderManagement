using CustomerOrderManagement.Application.Features.CustomerManagement.Commands.CreateCustomer;
using CustomerOrderManagement.Application.Features.CustomerManagement.Commands.DeleteCustomer;
using CustomerOrderManagement.Application.Features.CustomerManagement.Commands.UpdateCustomer;
using CustomerOrderManagement.Application.Features.CustomerManagement.Queries.GetAllCustomers;
using CustomerOrderManagement.Application.Features.CustomerManagement.Queries.GetCustomerById;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CustomerOrderManagement.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CustomerController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var query = new GetAllCustomersQuery();

            return Ok(await _mediator.Send(query));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOneCustomer(Guid id)
        {
            var query = new GetCustomerByIdQuery(id);

            return Ok(await _mediator.Send(query));

        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateCustomerCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute(Name = "id")] Guid id)
        {
            var command = new DeleteCustomerCommand(id);

            return Ok(await _mediator.Send(command));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateCustomerCommand updateCustomerCommand)
        {
            updateCustomerCommand.Id = id;

            return Ok(await _mediator.Send(updateCustomerCommand));
        }

    }
}
