using Micros.Application.Abstractions;
using Micros.Application.Models.ViewModels;
using Micros.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Micros.Application.UseCases.UserCases.Query
{
    public class GetAllUserByPositionQuery : IQuery<List<UserViewModel>>
    {
        public GetAllUserByPositionQuery() { }
        public Position Position { get; set; }
    }
}
