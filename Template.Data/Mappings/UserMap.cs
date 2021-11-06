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
<<<<<<< HEAD
<<<<<<< HEAD
            builder.Property(x => x.Email).IsRequired();
            builder.Property(x => x.Password).IsRequired();
            //builder.Property(x => x.Password).IsRequired().HasDefaultValue("TestePassword");
=======
            builder.Property(x => x.Password).IsRequired().HasDefaultValue("TestePassword");
>>>>>>> 976aa890d6b08c890828079776276d8d0483fb54
=======
            builder.Property(x => x.Password).IsRequired().HasDefaultValue("TestePassword");
>>>>>>> 976aa890d6b08c890828079776276d8d0483fb54
        }
    }
}
