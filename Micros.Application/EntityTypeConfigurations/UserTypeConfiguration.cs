﻿using Micros.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Micros.Application.EntityTypeConfigurations
{
    public class UserTypeConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasIndex(x => x.FirstName).IsUnique();
            builder.HasMany(c => c.InComes).WithOne(u => u.User).HasForeignKey(x => x.UserId);
            builder.HasMany(o => o.InComes).WithOne(u => u.User).HasForeignKey(x => x.UserId);
        }
    }
}
