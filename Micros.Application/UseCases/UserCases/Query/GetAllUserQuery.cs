using Micros.Application.Abstractions;
using Micros.Application.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Micros.Application.UseCases.UserCases.Query
{
    public class GetAllUserQuery : IQuery<List<UserViewModel>>
    {
        public GetAllUserQuery() { }
    }
}
