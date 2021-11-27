using System;
using System.Collections.Generic;
using System.Text;
using Template.Application.ViewModels;

namespace Template.Application.Interfaces
{
    public interface ISolicitacaoService
    {
        void Solicitar(Guid idFretista);
        void Excluir(Guid idSoliciatacao);
        void Aceitar(Guid idSolicitacao);
        void Recusar(Guid idSolicitacao);
        List<SolicitacaoViewModel> ConsultarServicosEncerrados();
        List<SolicitacaoViewModel> ConsultarServicosPendentes();
        List<SolicitacaoFretistaViewModel> ConsultarServicosPendentesFretista();
        List<SolicitacaoFretistaViewModel> ConsultarServicosEncerradosFretista();
    }
}
