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
        public int? UserId { get; set; }
        public int? Year { get; set; }
        public int? Month { get; set; }
        public int? Day { get; set; }
    }
}
