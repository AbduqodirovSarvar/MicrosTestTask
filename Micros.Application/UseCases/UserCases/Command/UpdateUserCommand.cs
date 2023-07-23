using Micros.Application.Abstractions;
using Micros.Application.Models.ViewModels;
using Micros.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Micros.Application.UseCases.UserCases.Command
{
    public class UpdateUserCommand : ICommand<UserViewModel>
    {
        public UpdateUserCommand() { }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Password { get; set; }
        public DateOnly? BirthDay { get; set; }
        public Gender? Gender { get; set; }
        public Position? Position { get; set; }
    }
}
