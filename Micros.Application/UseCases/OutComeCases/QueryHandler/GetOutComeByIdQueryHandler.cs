using AutoMapper;
using Micros.Application.Abstractions;
using Micros.Application.Models.ViewModels;
using Micros.Application.UseCases.OutComeCases.Query;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Micros.Application.UseCases.OutComeCases.QueryHandler
{
    public class GetOutComeByIdQueryHandler : IQueryHandler<GetOutComeByIdQuery,OutComeViewModel>
    {
        private readonly IAppDbContext _context;
        private readonly IMapper _mapper;
        public GetOutComeByIdQueryHandler(IAppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<OutComeViewModel> Handle(GetOutComeByIdQuery request, CancellationToken cancellationToken)
        {
            var outCome = await _context.OutComes.Include(x => x.User).FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
            if (outCome == null)
                throw new Exception();

            var viewModel = _mapper.Map<OutComeViewModel>(outCome);
            viewModel.User = _mapper.Map<UserViewModel>(outCome.User);

            return viewModel;
        }
    }
}
