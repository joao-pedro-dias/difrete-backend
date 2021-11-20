using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure.Annotations;
using System.Text;
using Template.Domain.Entities;

namespace Template.Data.Mappings
{
    public class UserMap:IEntityTypeConfiguration<User>
    {
        //mapeando usuário para entrar no sistema e gerar o token. Este processo está ligado ao ToKenService.cs
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(x => x.Id).IsRequired();
            builder.Property(x => x.Email).IsRequired(); 
            builder.Property(x => x.Password).IsRequired();
//          builder.Property(x => x.Password).IsRequired().HasDefaultValue("TestePassword");
        }
    }
}
