using Micros.Application.Abstractions;
using Micros.Application.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Micros.Application.UseCases.UserCases.Query
{
    public class GetUserQuery : IQuery<UserViewModel>
    {
        public GetUserQuery(int id) { Id = id; }
        public int Id { get; set; }
    }
}
