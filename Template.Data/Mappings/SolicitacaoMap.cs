using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure.Annotations;
using System.Text;
using Template.Domain.Entities;

namespace Template.Data.Mappings
{
    public class SolicitacaoMap:IEntityTypeConfiguration<Solicitacao>
    {
        public void Configure(EntityTypeBuilder<Solicitacao> builder)
        {
            builder.Property(x => x.Id).IsRequired();
            builder.Property(x => x.StatusId).IsRequired();
        }
    }
}
