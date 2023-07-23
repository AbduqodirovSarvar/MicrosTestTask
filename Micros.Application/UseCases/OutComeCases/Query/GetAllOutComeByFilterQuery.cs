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
        public int? UserId { get; set; } = null;
        public int? Year { get; set; } = null;
        public int? Month { get; set; } = null;
        public int? Day { get; set; } = null;
        public OutComeCategory? Category { get; set; }
    }
}
