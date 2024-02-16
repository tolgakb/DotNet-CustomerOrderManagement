using CustomerOrderManagement.Application.Common.Interfaces;
using CustomerOrderManagement.Domain.Constants;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerOrderManagement.Application.Features.UserManagement.Queries
{
    public record GetUserIsAdminQuery(string UserId) : IRequest<bool>;

    public class GetUserIsAdminQueryHandler : IRequestHandler<GetUserIsAdminQuery, bool>
    {
        private readonly IIdentityService _identityService;

        public GetUserIsAdminQueryHandler(IIdentityService identityService)
        {
            _identityService = identityService;
        }

        public async Task<bool> Handle(GetUserIsAdminQuery request, CancellationToken cancellationToken)
        {
            return await _identityService.IsInRoleAsync(request.UserId, Roles.Administrator);
        }

    }
}
