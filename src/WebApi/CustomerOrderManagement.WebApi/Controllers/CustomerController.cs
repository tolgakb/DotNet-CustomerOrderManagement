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
        private readonly ILogger<CustomerController> _logger;

        public CustomerController(IMediator mediator, ILogger<CustomerController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var query = new GetAllCustomersQuery();

            _logger.LogInformation("All customers have been received successfully.");

            return Ok(await _mediator.Send(query));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOneCustomer(Guid id)
        {
            var query = new GetCustomerByIdQuery(id);

            _logger.LogInformation("Customer has been been successfully received according to id number.");

            return Ok(await _mediator.Send(query));

        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateCustomerCommand command)
        {
            if(command is null)
            {
                return BadRequest();
            }

            _logger.LogInformation("Customer has been created successfully.");


            return Ok(await _mediator.Send(command));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute(Name = "id")] Guid id)
        {
            var command = new DeleteCustomerCommand(id);

            _logger.LogInformation("Customer has been deleted successfully.");


            return Ok(await _mediator.Send(command));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateCustomerCommand updateCustomerCommand)
        {
            if(updateCustomerCommand is null)
            {
                return BadRequest();
            }

            updateCustomerCommand.Id = id;

            _logger.LogInformation("Customer has been updated successfully.");

            return Ok(await _mediator.Send(updateCustomerCommand));
        }

    }
}
