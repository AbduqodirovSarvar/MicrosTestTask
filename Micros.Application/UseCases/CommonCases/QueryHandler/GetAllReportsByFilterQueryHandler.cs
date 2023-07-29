using AutoMapper;
using Micros.Application.Abstractions;
using Micros.Application.Models.ViewModels;
using Micros.Application.UseCases.CommonCases.Query;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Micros.Application.UseCases.CommonCases.QueryHandler
{
    public class GetAllReportsByFilterQueryHandler : IQueryHandler<GetAllReportsByFilterQuery, ReportViewModel>
    {
        private readonly IAppDbContext _context;
        private readonly IMapper _mapper;

        public GetAllReportsByFilterQueryHandler(IAppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<ReportViewModel> Handle(GetAllReportsByFilterQuery request, CancellationToken cancellationToken)
        {
            var inComes = await _context.InComes.Include(x => x.User).ToListAsync(cancellationToken);
            var outComes = await _context.OutComes.Include(x => x.User).ToListAsync(cancellationToken);
            if (request?.UserId != null)
            {
                inComes = inComes.Where(x => x.UserId== request.UserId).ToList();
                outComes = outComes.Where(x => x.UserId == request.UserId).ToList();
            }
            if (request?.Year != null)
            {
                inComes = inComes.Where(x => x.CreatedDate.Year == request.Year).ToList();
                outComes = outComes.Where(x => x.CreatedDate.Year == request.Year).ToList();
            }
            if (request?.Month != null)
            {
                inComes = inComes.Where(x => x.CreatedDate.Month == request.Month).ToList();
                outComes = outComes.Where(x => x.CreatedDate.Month == request.Month).ToList();
            }
            if (request?.Day != null)
            {
                inComes = inComes.Where(x => x.CreatedDate.Day == request.Day).ToList();
                outComes = outComes.Where(x => x.CreatedDate.Day == request.Day).ToList();
            }

            List<InComeViewModel> inComeViewModel = new List<InComeViewModel>();
            foreach(var inCome in inComes)
            {
                var come = _mapper.Map<InComeViewModel>(inCome);
                come.User = _mapper.Map<UserViewModel>(inCome.User);
                inComeViewModel.Add(come);
            }

            List<OutComeViewModel> outComeViewModel = new List<OutComeViewModel>();
            foreach(var outCome in outComes)
            {
                var comeOut = _mapper.Map<OutComeViewModel>(outCome);
                comeOut.User = _mapper.Map<UserViewModel>(outCome.User);
                outComeViewModel.Add(comeOut);
            }

            ReportViewModel reportView = new ReportViewModel(inComeViewModel, outComeViewModel);
            reportView.OutcomeTotalSumms = outComeViewModel.Select(x => x.Amount).Sum();
            reportView.IncomeTotalSumms = inComeViewModel.Select(x => x.Amount).Sum();

            return reportView;
        }
    }
}
