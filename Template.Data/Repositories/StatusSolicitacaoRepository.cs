using System;
using System.Collections.Generic;
using System.Linq;
using Template.Application.ViewModels;
using Template.Data.Context;
using Template.Domain.Entities;
using Template.Domain.Interfaces;

namespace Template.Data.Repositories
{
    public class StatusSolicitacaoRepository : Repository<StatusSolicitacao>, IStatusSolicitacaoRepository
    {
        public StatusSolicitacaoRepository(TemplateContext context) : base(context) { }
    }
}
