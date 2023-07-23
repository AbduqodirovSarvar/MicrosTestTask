using AutoMapper;
using Micros.Application.Abstractions;
using Micros.Application.Models.ViewModels;
using Micros.Application.UseCases.OutComeCases.Command;
using Micros.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Micros.Application.UseCases.OutComeCases.CommandHandler
{
    public class CreateOutComeCommandHandler : ICommandHandler<CreateOutComeCommand, OutComeViewModel>
    {
        private readonly IAppDbContext _context;
        private readonly IMapper _mapper;
        private readonly ICurrentUserService _currentUserService;
        public CreateOutComeCommandHandler(IAppDbContext context, IMapper mapper, ICurrentUserService currentUserService)
        {
            _context = context;
            _mapper = mapper;
            _currentUserService = currentUserService;
        }

        public async Task<OutComeViewModel> Handle(CreateOutComeCommand request, CancellationToken cancellationToken)
        {
            var outCome = _mapper.Map<OutCome>(request);
            outCome.UserId = _currentUserService.UserId;
            DateTime date = DateTime.UtcNow;
            outCome.CreatedDate = date;
            await _context.OutComes.AddAsync(outCome, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return _mapper.Map<OutComeViewModel>(await _context.OutComes.FirstOrDefaultAsync(x => x.CreatedDate == date, cancellationToken));
        }
    }
}
