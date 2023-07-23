using Micros.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Micros.Domain.Entities
{
    public class InCome
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User? User { get; set; }
        public decimal Amount { get; set; }
        public InComeCategory Category { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
    }
}
