using Micros.Application.Abstractions;
using Micros.Application.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Micros.Application.UseCases.UserCases.Command
{
    public class DeleteUserCommand : ICommand<UserViewModel>
    {
        public DeleteUserCommand(int id)
        {
            Id = id;
        }
        public int Id { get; set; }
    }
}
