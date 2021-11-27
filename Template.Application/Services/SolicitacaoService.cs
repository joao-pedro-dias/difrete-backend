using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using Template.Application.Interfaces;
using Template.Application.ViewModels;
using Template.Domain.Entities;
using Template.Domain.Enums;
using Template.Domain.Interfaces;

namespace Template.Application.Services
{
    public class SolicitacaoService : ISolicitacaoService
    {
        private IAuthService _authService;
        private IFretistaRepository _fretistaRepository;
        private ISolicitacaoRepository _solicitacaoRepository;
        private IStatusSolicitacaoRepository statusSolicitacaoRepository;

        public SolicitacaoService(IAuthService authService, IFretistaRepository fretistaRepository, ISolicitacaoRepository solicitacaoRepository, IStatusSolicitacaoRepository statusSolicitacaoRepository)
        {
            _authService = authService;
            _fretistaRepository = fretistaRepository;
            _solicitacaoRepository = solicitacaoRepository;
            this.statusSolicitacaoRepository = statusSolicitacaoRepository;
        }

        public void Aceitar(Guid idSolicitacao)
        {
            var solicitacao = _solicitacaoRepository.Find(x => x.Id == idSolicitacao);
            var statusAceito = statusSolicitacaoRepository.Find(x => x.Descricao == StatusSolicitacaoEnum.ACEITO.ToString());
            solicitacao.StatusId = statusAceito.Id;
            _solicitacaoRepository.Update(solicitacao);
        }

        public void Excluir(Guid idSolicitacao)
        {
            var solicitacao = _solicitacaoRepository.Find(x => x.Id == idSolicitacao);
            _solicitacaoRepository.Delete(solicitacao);
        }

        public List<SolicitacaoViewModel> ConsultarServicosEncerrados()
        {
            List<string> finishedStatus = new List<string>();
            finishedStatus.Add(StatusSolicitacaoEnum.RECUSADO.ToString());
            finishedStatus.Add(StatusSolicitacaoEnum.ACEITO.ToString());

            return _solicitacaoRepository.GetByStatus(_authService.GetPerson().Id, finishedStatus);
        }

        public List<SolicitacaoViewModel> ConsultarServicosPendentes()
        {
            List<string> finishedStatus = new List<string>();
            finishedStatus.Add(StatusSolicitacaoEnum.PENDENTE.ToString());

            return _solicitacaoRepository.GetByStatus(_authService.GetPerson().Id, finishedStatus);
        }

        public void Recusar(Guid idSolicitacao)
        {
            var solicitacao = _solicitacaoRepository.Find(x => x.Id == idSolicitacao);
            var statusAceito = statusSolicitacaoRepository.Find(x => x.Descricao == StatusSolicitacaoEnum.RECUSADO.ToString());
            solicitacao.StatusId = statusAceito.Id;
            _solicitacaoRepository.Update(solicitacao);
        }

        public void Solicitar(Guid idFretista)
        {
            var fretista = _fretistaRepository.Find(x => x.Id.Equals(idFretista));
            var person = _authService.GetPerson();
            var statusPendente = statusSolicitacaoRepository.Find(x => x.Descricao.Equals(StatusSolicitacaoEnum.PENDENTE.ToString()));
            var solicitacao = new Solicitacao();
            solicitacao.PersonId = person.Id;
            solicitacao.FretistaId = fretista.Id;
            solicitacao.StatusId = statusPendente.Id;


            _solicitacaoRepository.Create(solicitacao);
        }

        public List<SolicitacaoFretistaViewModel> ConsultarServicosPendentesFretista()
        {
            List<string> finishedStatus = new List<string>();
            finishedStatus.Add(StatusSolicitacaoEnum.PENDENTE.ToString());

            return _solicitacaoRepository.GetForFretistaByStatus(_authService.GetFretista().Id, finishedStatus);
        }

        public List<SolicitacaoFretistaViewModel> ConsultarServicosEncerradosFretista()
        {
            List<string> finishedStatus = new List<string>();
            finishedStatus.Add(StatusSolicitacaoEnum.RECUSADO.ToString());
            finishedStatus.Add(StatusSolicitacaoEnum.ACEITO.ToString());

            return _solicitacaoRepository.GetForFretistaByStatus(_authService.GetFretista().Id, finishedStatus);
        }
    }
}
