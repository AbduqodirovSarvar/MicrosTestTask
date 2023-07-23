using Micros.Application.Abstractions;
using Micros.Application.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Micros.Application.UseCases.OutComeCases.Query
{
    public class GetOutComeByIdQuery : IQuery<OutComeViewModel>
    {
        public GetOutComeByIdQuery(int id) { Id = id; }
        [Required]
        public int Id { get; set; }
    }
}
