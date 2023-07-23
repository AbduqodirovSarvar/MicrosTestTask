using Micros.Application.Abstractions;
using Micros.Application.Models.ViewModels;
using Micros.Domain.Entities;
using Micros.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Micros.Application.UseCases.InComeCases.Command
{
    public class CreateInComeCommand : ICommand<InComeViewModel>
    {
        public CreateInComeCommand() { }
        [Required]
        public decimal Amount { get; set; }
        [Required]
        public InComeCategory Category { get; set; }
    }
}
