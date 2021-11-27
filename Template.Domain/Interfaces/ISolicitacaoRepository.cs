using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Template.Application.ViewModels;
using Template.Domain.Entities;
using Template.Domain.Enums;

namespace Template.Domain.Interfaces
{
    public interface ISolicitacaoRepository : IRepository<Solicitacao>
    {
        public List<SolicitacaoViewModel> GetByStatus(Guid PersonId, List<string> status);
        public List<SolicitacaoFretistaViewModel> GetForFretistaByStatus(Guid FretistaId, List<string> status);
    }
}
