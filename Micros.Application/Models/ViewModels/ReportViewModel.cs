using Micros.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Micros.Application.Models.ViewModels
{
    public class ReportViewModel
    {
        public ReportViewModel(List<InComeViewModel> inComeList, List<OutComeViewModel> outComeList) 
        {
            InComeList = inComeList;
            OutComeList = outComeList;
        }
        public List<InComeViewModel> InComeList { get; set;} = new List<InComeViewModel>();
        public List<OutComeViewModel> OutComeList { get; set; } = new List<OutComeViewModel>();
    }
}
