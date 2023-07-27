using AutoMapper;
using Micros.Application.Abstractions;
using Micros.Application.Models.ViewModels;
using Micros.Application.UseCases.UserCases.Command;
using Micros.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Micros.Application.UseCases.UserCases.CommandHandler
{
    public class CreateUserCommandHandler : ICommandHandler<CreateUserCommand, UserViewModel>
    {
        private readonly IAppDbContext _context;
        private readonly IMapper _mapper;
        private readonly IHashService _hashService;
        public CreateUserCommandHandler(IAppDbContext context, IMapper mapper, IHashService hashService)
        {
            _context = context;
            _mapper = mapper;
            _hashService = hashService;
        }

        public async Task<UserViewModel> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.FirstName == request.FirstName, cancellationToken);
            if (user != null)
                throw new Exception();

            user = _mapper.Map<User>(request);
            user.Password = _hashService.GetHash(request.Password);
            user.BirthDay = request.BirthDay;
            user.CreatedTime = DateTime.UtcNow;

            await _context.Users.AddAsync(user, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return _mapper.Map<UserViewModel>(user);
        }
    }
}
