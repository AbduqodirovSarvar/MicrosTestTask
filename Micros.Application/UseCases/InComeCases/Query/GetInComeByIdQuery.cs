using Micros.Application.Abstractions;
using Micros.Application.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Micros.Application.UseCases.InComeCases.Query
{
    public class GetInComeByIdQuery : IQuery<InComeViewModel>
    {
        public GetInComeByIdQuery(int id) { Id = id; }
        public int Id { get; set; }
    }
}
