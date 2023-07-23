using Micros.Domain.Entities;
using Micros.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Micros.Application.Models.ViewModels
{
    public class OutComeViewModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public decimal Amount { get; set; }
        public OutComeCategory Category { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
