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
    public class GetAllInComeByFilterQueryHandler : IQueryHandler<GetAllInComeByFilterQuery, List<InComeViewModel>>
    {
        private readonly IAppDbContext _context;
        private readonly IMapper _mapper;
        public GetAllInComeByFilterQueryHandler(IAppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<InComeViewModel>> Handle(GetAllInComeByFilterQuery request, CancellationToken cancellationToken)
        {
            var inComes = await _context.InComes.ToListAsync(cancellationToken);
            if (request?.UserId != null)
            {
                inComes = inComes.Where(x => x.UserId == request.UserId).ToList();
            }

            if (request?.Year != null)
            {
                inComes = inComes.Where(x => x.CreatedDate.Year == request.Year).ToList();
            }

            if (request?.Month != null)
            {
                inComes = inComes.Where(x => x.CreatedDate.Month == request.Month).ToList();
            }

            if (request?.Day != null)
            {
                inComes = inComes.Where(x => x.CreatedDate.Day == request.Day).ToList();
            }

            return _mapper.Map<List<InComeViewModel>>(inComes);
        }
    }
}
