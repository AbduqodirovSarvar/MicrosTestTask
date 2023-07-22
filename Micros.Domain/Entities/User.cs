using Micros.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Micros.Domain.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Password = "Password";
        public decimal Balance { get; set; }
        public DateOnly BirthDay { get; set; } = new DateOnly(DateTime.UtcNow.Year, DateTime.UtcNow.Month, DateTime.UtcNow.Day);
        public Gender Gender { get; set; }
        public Position Position { get; set; }
        public DateTime CreatedTime { get; set; } = DateTime.UtcNow;

        public ICollection<InCome> InComes { get; set; } = new HashSet<InCome>();
        public ICollection<OutCome> OutComes { get; set; } = new HashSet<OutCome>();
    }
}
