using Micros.Application.Abstractions;
using Micros.Domain.Entities;
using Micros.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Micros.Infrastucture.DbContexts
{
    public class AppDbContext : DbContext, IAppDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) 
            : base(options) { }
        public DbSet<User> Users { get; set; }
        public DbSet<InCome> InComes { get; set; }
        public DbSet<OutCome> OutComes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
            modelBuilder.Entity<User>().HasData(new User
            {
                FirstName = "Admin",
                LastName = "Admin",
                Password = "DefaultAdminPassword",
                Gender = Gender.Male,
                Position = Position.Admin
            });
        }
    }
}