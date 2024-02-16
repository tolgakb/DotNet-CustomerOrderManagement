using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerOrderManagement.Application.Features.Authentication.Commands.AuthUserCommand
{
    public class AuthResponseDto
    {
        public string? UserId { get; set; }

        public string? Name { get; set; }

        public string? Email { get; set; }

        public IList<string> Roles { get; set; } = new List<string>();

        public string? Token { get; set; }
    }
}
