using AutoMapper;
using Micros.Application.Abstractions;
using Micros.Application.Models.ViewModels;
using Micros.Application.UseCases.UserCases.Command;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Micros.Application.UseCases.UserCases.CommandHandler
{
    public class DeleteUserCommandHandler : ICommandHandler<DeleteUserCommand, UserViewModel>
    {
        private readonly IAppDbContext _context;
        private readonly IMapper _mapper;
        public DeleteUserCommandHandler(IAppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<UserViewModel> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
            if (user == null)
                throw new Exception();

            _context.Users.Remove(user);
            await _context.SaveChangesAsync(cancellationToken);
            return _mapper.Map<UserViewModel>(user);
        }
    }
}
