using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using Template.Domain.Entities;

namespace Template.Data.Mappings
{
    public class UserMap:IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(x => x.Id).IsRequired();
            builder.Property(x => x.Name).HasMaxLength(100).IsRequired();
            builder.Property(x => x.Password).IsRequired().HasDefaultValue("TestePassword");
            builder.Property(x => x.Cpf).IsRequired().HasDefaultValue("12345678910");
            builder.Property(x => x.Celular).IsRequired().HasDefaultValue("17982310203");


        }
    }
}
