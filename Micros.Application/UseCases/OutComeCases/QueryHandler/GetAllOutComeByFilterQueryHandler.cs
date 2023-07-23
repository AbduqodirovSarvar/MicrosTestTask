using AutoMapper;
using Micros.Application.Abstractions;
using Micros.Application.Models.ViewModels;
using Micros.Application.UseCases.InComeCases.Query;
using Micros.Application.UseCases.OutComeCases.Query;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Micros.Application.UseCases.OutComeCases.QueryHandler
{
    public class GetAllOutComeByFilterQueryHandler : IQueryHandler<GetAllOutComeByFilterQuery, List<OutComeViewModel>>
    {
        private readonly IAppDbContext _context;
        private readonly IMapper _mapper;
        public GetAllOutComeByFilterQueryHandler(IAppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<List<OutComeViewModel>> Handle(GetAllOutComeByFilterQuery request, CancellationToken cancellationToken)
        {
            var outComes = await _context.OutComes.ToListAsync(cancellationToken);
            if (request?.UserId != null)
            {
                outComes = outComes.Where(x => x.UserId == request.UserId).ToList();
            }

            if (request?.Year != null)
            {
                outComes = outComes.Where(x => x.CreatedDate.Year == request.Year).ToList();
            }

            if (request?.Month != null)
            {
                outComes = outComes.Where(x => x.CreatedDate.Month == request.Month).ToList();
            }

            if (request?.Day != null)
            {
                outComes = outComes.Where(x => x.CreatedDate.Day == request.Day).ToList();
            }

            return _mapper.Map<List<OutComeViewModel>>(outComes);
        }
    }
}
