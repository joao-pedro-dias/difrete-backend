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
            throw new NotImplementedException();
        }

        public void Cancelar(Guid idSoliciatacao)
        {
            throw new NotImplementedException();
        }

        public List<SolicitacaoViewModel> ConsltarServicosEcerrados()
        {
            throw new NotImplementedException();
        }

        public List<SolicitacaoViewModel> CosultarServicosPendentes()
        {
            throw new NotImplementedException();
        }

        public void Recusar(Guid idSolicitacao)
        {
            throw new NotImplementedException();
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
    }
}
