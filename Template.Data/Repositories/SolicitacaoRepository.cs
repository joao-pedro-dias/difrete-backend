using System;
using System.Collections.Generic;
using System.Linq;
using Template.Application.ViewModels;
using Template.Data.Context;
using Template.Domain.Entities;
using Template.Domain.Enums;
using Template.Domain.Interfaces;

namespace Template.Data.Repositories
{
    public class SolicitacaoRepository : Repository<Solicitacao>, ISolicitacaoRepository
    {
        public SolicitacaoRepository(TemplateContext context) : base(context) { }

        public List<SolicitacaoViewModel> GetByStatus(Guid PersonId, List<string> status)
        {
            return _context.Solicitacoes
                .Where(x => status.Contains(x.Status.Descricao) && x.PersonId == PersonId)
                .Select(x => new SolicitacaoViewModel(x, x.Status, x.Fretista, x.Fretista.User.Person, x.Fretista.User))
                .ToList();
        }

        public List<SolicitacaoFretistaViewModel> GetForFretistaByStatus(Guid FretistaId, List<string> status)
        {
            return _context.Solicitacoes
                .Where(x => status.Contains(x.Status.Descricao) && x.FretistaId == FretistaId)
                .Select(x => new SolicitacaoFretistaViewModel(x.Id, x.Status, x.Person, x.Person.User))
                .ToList();
        }
    }
}
