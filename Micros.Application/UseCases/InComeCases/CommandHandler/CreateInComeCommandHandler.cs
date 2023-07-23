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
        public CreateInComeCommandHandler(IAppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<InComeViewModel> Handle(CreateInComeCommand request, CancellationToken cancellationToken)
        {
            var inCome = _mapper.Map<InCome>(request);
            DateTime date = DateTime.UtcNow;
            inCome.CreatedDate = date;
            await _context.InComes.AddAsync(inCome, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return _mapper.Map<InComeViewModel>(await _context.InComes.FirstOrDefaultAsync(x => x.CreatedDate == date, cancellationToken));
        }
    }
}
