﻿using Micros.Application.Abstractions;
using Micros.Application.Models.ViewModels;
using Micros.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Micros.Application.UseCases.OutComeCases.Command
{
    public class CreateOutComeCommand : ICommand<OutComeViewModel>
    {
        public CreateOutComeCommand() { }
        [Required]
        public decimal Amount { get; set; }
        [Required]
        public OutComeCategory Category { get; set; }
    }
}
