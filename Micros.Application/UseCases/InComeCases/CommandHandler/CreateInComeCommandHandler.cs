using AutoMapper;
using Micros.Application.Abstractions;
using Micros.Application.Models.ViewModels;
using Micros.Application.UseCases.InComeCases.Command;
using Micros.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Micros.Application.UseCases.InComeCases.CommandHandler
{
    public class CreateInComeCommandHandler : ICommandHandler<CreateInComeCommand, InComeViewModel>
    {
        private readonly IAppDbContext _context;
        private readonly IMapper _mapper;
        private readonly ICurrentUserService _currentUserService;
        public CreateInComeCommandHandler(IAppDbContext context, IMapper mapper, ICurrentUserService currentUserService)
        {
            _context = context;
            _mapper = mapper;
            _currentUserService = currentUserService;
        }

        public async Task<InComeViewModel> Handle(CreateInComeCommand request, CancellationToken cancellationToken)
        {
            var inCome = _mapper.Map<InCome>(request);
            inCome.UserId = _currentUserService.UserId;
            DateTime date = DateTime.UtcNow;
            inCome.CreatedDate = date;
            await _context.InComes.AddAsync(inCome, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            var viewModel = _mapper.Map<InComeViewModel>(inCome);
            viewModel.User = _mapper.Map<UserViewModel>(await _context.Users.FirstOrDefaultAsync(x => x.Id == inCome.UserId, cancellationToken));

            return viewModel;
        }
    }
}
