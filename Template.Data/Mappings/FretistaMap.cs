using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using Template.Domain.Entities;

namespace Template.Data.Mappings
{
    public class FretistaMap : IEntityTypeConfiguration<Fretista>
    {
        //mapeando o fretista, que por sinal também é um usuário que possui ID, email e senha conforme UserMap.cs
        public void Configure(EntityTypeBuilder<Fretista> builder)
        {
            builder.Property(x => x.Id).IsRequired();
            builder.Property(x => x.RazaoSocial).IsRequired();
            builder.Property(x => x.Cnpj).IsRequired();
            builder.Property(x => x.Rntrc).IsRequired().HasDefaultValue("12345678910");

        }
    }
}
