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
    public class UpdateUserCommandHandler : ICommandHandler<UpdateUserCommand, UserViewModel>
    {
        private readonly IAppDbContext _context;
        private readonly IMapper _mapper;
        private readonly ICurrentUserService _currentUserService;
        private readonly IHashService _hashService;

        public UpdateUserCommandHandler(IAppDbContext dbContext, IMapper mapper, ICurrentUserService currentUserService, IHashService hashService)
        {
            _context = dbContext;
            _mapper = mapper;
            _currentUserService = currentUserService;
            _hashService = hashService;
        }
        public async Task<UserViewModel> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == _currentUserService.UserId, cancellationToken);
            if (user == null)
                throw new Exception();

            user.FirstName = request?.FirstName ?? user.FirstName;
            user.LastName = request?.LastName ?? user.LastName;
            user.Position = request?.Position ?? user.Position;
            if (request?.Password != null)
            {
                user.Password = _hashService.GetHash(request.Password);
            }
            if (request?.Year != null && request?.Month != null && request?.Day != null)
            {
                user.BirthDay = new DateOnly(request.Year.Value, request.Month.Value, request.Day.Value);
            }
            
            return _mapper.Map<UserViewModel>(user);
        }
    }
}
