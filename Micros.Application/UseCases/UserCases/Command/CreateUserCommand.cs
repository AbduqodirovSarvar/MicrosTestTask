using Micros.Application.Models.ViewModels;
using System.Windows.Input;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Micros.Application.Abstractions;
using Micros.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace Micros.Application.UseCases.UserCases.Command
{
    public class CreateUserCommand : ICommand<UserViewModel>
    {
        [Required]
        public string FirstName { get; set; } = string.Empty;
        [Required]
        public string LastName { get; set; } = string.Empty;
        [Required]
        public string Password { get; set; } = string.Empty;
        [Required]
        public decimal Balance { get; set; }
        [Required]
        public DateOnly BirthDay { get; set; }
        [Required]
        public Gender Gender { get; set; }
        [Required]
        public Position Position { get; set; }
    }
}
