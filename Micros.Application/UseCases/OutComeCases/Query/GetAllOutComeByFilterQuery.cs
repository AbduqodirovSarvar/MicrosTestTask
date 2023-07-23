using Micros.Application.Abstractions;
using Micros.Application.Models.ViewModels;
using Micros.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Micros.Application.UseCases.OutComeCases.Query
{
    public class GetAllOutComeByFilterQuery : IQuery<List<OutComeViewModel>>
    {
        public GetAllOutComeByFilterQuery() { }
        public int? UserId { get; set; }
        public int? Year { get; set; }
        public int? Month { get; set; }
        public int? Day { get; set; }
        public OutComeCategory? Category { get; set; }
    }
}
