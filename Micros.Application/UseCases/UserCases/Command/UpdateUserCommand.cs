using Micros.Application.Abstractions;
using Micros.Application.Models.ViewModels;
using Micros.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Micros.Application.UseCases.UserCases.Command
{
    public class UpdateUserCommand : ICommand<UserViewModel>
    {
        public UpdateUserCommand() { }
        public string? FirstName { get; set; } = null;
        public string? LastName { get; set; } = null;
        public string? Password { get; set; } = null;
        public int? Year { get; set; } = null;
        public int? Month { get; set; } = null;
        public int? Day { get; set; } = null;
        public Gender? Gender { get; set; } = null;
        public Position? Position { get; set; } = null;
    }
}
