using Micros.Application.Abstractions;
using Micros.Application.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Micros.Application.UseCases.OutComeCases.Query
{
    public class GetOutComeByIdQuery : IQuery<OutComeViewModel>
    {
        public GetOutComeByIdQuery(int id) { Id = id; }
        public int Id { get; set; }
    }
}
