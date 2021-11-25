using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure.Annotations;
using System.Text;
using Template.Domain.Entities;

namespace Template.Data.Mappings
{
    public class StatusSolicitacaoMap : IEntityTypeConfiguration<StatusSolicitacao>
    {
        public void Configure(EntityTypeBuilder<StatusSolicitacao> builder)
        {
            builder.Property(x => x.Id).IsRequired();
            builder.Property(x => x.Descricao).IsRequired();
            builder.Property(x => x.IsStatusFinal).IsRequired();
        }
    }
}
