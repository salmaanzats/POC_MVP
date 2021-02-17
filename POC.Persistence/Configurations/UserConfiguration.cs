using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using POC.Domain.Entitities;
using System;
using System.Collections.Generic;
using System.Text;

namespace POC.Persistence.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(e => e.FirstName)
                .IsRequired()
                .HasMaxLength(50);


            builder.Property(e => e.LastName)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(e => e.Address)
               .IsRequired()
               .HasMaxLength(900);

            builder.Property(e => e.School)
               .IsRequired()
               .HasMaxLength(200);
        }
    }
}
