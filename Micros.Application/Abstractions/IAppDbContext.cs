using Micros.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Micros.Application.Abstractions
{
    public interface IAppDbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<InCome> InComes { get; set; }
        public DbSet<OutCome> OutComes { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
