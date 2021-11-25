using System;
using System.Collections.Generic;
using System.Text;
using Template.Application.ViewModels;

namespace Template.Application.Interfaces
{
    public interface ISolicitacaoService
    {
        void Solicitar(Guid idFretista);
        void Cancelar(Guid idSoliciatacao);
        void Aceitar(Guid idSolicitacao);
        void Recusar(Guid idSolicitacao);
        List<SolicitacaoViewModel> ConsltarServicosEcerrados();
        List<SolicitacaoViewModel> CosultarServicosPendentes();
    }
}
