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
    public class CreateOutComeCommandHandler : ICommandHandler<CreateoutComeCommand, OutComeViewModel>
    {
        private readonly IAppDbContext _context;
        private readonly IMapper _mapper;
        public CreateOutComeCommandHandler(IAppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<OutComeViewModel> Handle(CreateoutComeCommand request, CancellationToken cancellationToken)
        {
            var outCome = _mapper.Map<OutCome>(request);
            DateTime date = DateTime.UtcNow;
            outCome.CreatedDate = date;
            await _context.OutComes.AddAsync(outCome, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return _mapper.Map<OutComeViewModel>(await _context.OutComes.FirstOrDefaultAsync(x => x.CreatedDate == date, cancellationToken));
        }
    }
}
