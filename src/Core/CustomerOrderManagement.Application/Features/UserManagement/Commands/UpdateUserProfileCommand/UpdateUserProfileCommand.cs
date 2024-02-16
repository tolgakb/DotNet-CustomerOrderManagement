using Ardalis.GuardClauses;
using CustomerOrderManagement.Application.Common.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerOrderManagement.Application.Features.UserManagement.Commands.UpdateUserProfileCommand
{
    public class UpdateUserProfileCommand : IRequest
    {
        public string? UserId { get; set; }

        public string? FullName { get; set; }
    }

    internal class UpdateUserProfileCommandHandler : IRequestHandler<UpdateUserProfileCommand>
    {
        private readonly IApplicationDbContext _context;

        public UpdateUserProfileCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Handle(UpdateUserProfileCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Users
                .FindAsync(new object[] { request.UserId! }, cancellationToken);

            Guard.Against.NotFound(request.UserId!, entity);

            entity.FullName = request.FullName!;

            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
