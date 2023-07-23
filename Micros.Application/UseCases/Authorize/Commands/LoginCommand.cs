using Micros.Application.Abstractions;
using Micros.Application.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Micros.Application.UseCases.Authorize.Commands
{
    public class LoginCommand : ICommand<LoginViewModel>
    {
        [Required]
        public string FirstName { get; set; } = string.Empty;
        [Required]
        public string Password { get; set; } = "Password";
    }
}
