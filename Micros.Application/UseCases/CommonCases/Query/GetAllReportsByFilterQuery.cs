using Micros.Application.Abstractions;
using Micros.Application.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Micros.Application.UseCases.CommonCases.Query
{
    public class GetAllReportsByFilterQuery : IQuery<ReportViewModel>
    {
        public GetAllReportsByFilterQuery() { }
        public int? UserId { get; set; } = null;
        public int? Year { get; set; } = null;
        public int? Month { get; set; } = null;
        public int? Day { get; set; } = null;
    }
}
