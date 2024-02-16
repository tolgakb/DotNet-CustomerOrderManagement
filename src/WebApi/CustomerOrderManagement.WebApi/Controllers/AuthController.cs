using CustomerOrderManagement.Application.Features.Authentication.Commands.AuthUserCommand;
using CustomerOrderManagement.Application.Features.Authentication.Commands.CreateUserCommand;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CustomerOrderManagement.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("Register")]
        public async Task<string> CreateUser([FromBody] CreateUserCommand command)
        {
            return await _mediator.Send(command);
        }

        [HttpPost("Login")]
        public async Task<AuthResponseDto> Login([FromBody] AuthUserCommand command)
        {
            return await _mediator.Send(command);
        }


    }
}
