using Micros.Application.Abstractions;
using Micros.Application.Models.ViewModels;
using Micros.Application.UseCases.Authorize.Commands;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Micros.Application.UseCases.Authorize.CommandHandler
{
    public class LoginCommandHandler : ICommandHandler<LoginCommand, LoginViewModel>
    {
        private readonly IAppDbContext _context;
        private readonly ITokenService _tokenService;
        private readonly IHashService _hashService;

        public LoginCommandHandler(IAppDbContext context, ITokenService tokenService, IHashService hashService)
        {
            _context = context;
            _tokenService = tokenService;
            _hashService = hashService;
        }

        public async Task<LoginViewModel> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.FirstName.ToLower() == request.Name.ToLower(), cancellationToken);
            if (user == null || user.Password != _hashService.GetHash(request.Password))
                throw new Exception();

            var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                    new Claim(ClaimTypes.Role, user.Position.ToString())
                };

            var loginView = new LoginViewModel();
            loginView.AccessToken = _tokenService.GetAccessToken(claims.ToArray());
            return loginView;
        }
    }
}
