using AutoMapper;
using Micros.Application.Abstractions;
using Micros.Application.Models.ViewModels;
using Micros.Application.UseCases.InComeCases.Query;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Micros.Application.UseCases.InComeCases.QueryHandler
{
    public class GetInComeByIdQueryHandler : IQueryHandler<GetInComeByIdQuery, InComeViewModel>
    {
        private readonly IAppDbContext _context;
        private readonly IMapper _mapper;
        public GetInComeByIdQueryHandler(IAppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<InComeViewModel> Handle(GetInComeByIdQuery request, CancellationToken cancellationToken)
        {
            var inCome = await _context.InComes.Include(x => x.User).FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
            if (inCome == null)
                throw new Exception();

            var viewModel = _mapper.Map<InComeViewModel>(inCome);
            viewModel.User = _mapper.Map<UserViewModel>(inCome.User);

            return viewModel;
        }
    }
}
