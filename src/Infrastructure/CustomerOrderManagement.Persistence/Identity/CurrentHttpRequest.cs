using CustomerOrderManagement.Application.Common.Interfaces;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerOrderManagement.Persistence.Identity
{
    internal class CurrentHttpRequest : ICurrentHttpRequest
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CurrentHttpRequest(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public string? GetUserId()
        {
            return _httpContextAccessor.HttpContext!.User.FindFirst(JwtRegisteredClaimNames.Jti)?.Value;
        }
    }
}
