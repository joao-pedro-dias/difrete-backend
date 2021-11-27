using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Template.Application.Interfaces;
using Template.Application.Services;
using Template.Application.ViewModels;
using Template.Auth.Services;

namespace Template.Controllers
{
    [Route("api/[controller]")]
    [ApiController, Authorize]
    public class SolicitacaoController : ControllerBase
    {
        private readonly ISolicitacaoService solicitacaoService;

        public SolicitacaoController(ISolicitacaoService solicitacaoService)
        {
            this.solicitacaoService = solicitacaoService;
        }

        [HttpPost("{fretistaId}/solicitar")]
        public IActionResult SolicitarServico(Guid fretistaId)
        {
            this.solicitacaoService.Solicitar(fretistaId);
            return Ok();
        }

        [HttpDelete("{solicitacaoId}/excluir")]
        public IActionResult ExcluirSolicitacao(Guid solicitacaoId)
        {
            this.solicitacaoService.Excluir(solicitacaoId);
            return Ok();
        }

        //Método REST patch serve para alterar um atriuto. Nesse caso o status.
        [HttpPatch("{solicitacaoId}/aceitar")]
        public IActionResult AceitarSolicitacao(Guid solicitacaoId)
        {
            this.solicitacaoService.Aceitar(solicitacaoId);
            return Ok();
        }

        [HttpPatch("{solicitacaoId}/recusar")]
        public IActionResult RecusarSolicitacao(Guid solicitacaoId)
        {
            this.solicitacaoService.Recusar(solicitacaoId);
            return Ok();
        }

        [HttpGet("encerradas")]
        public IActionResult ConsultarServicosEncerrados()
        {
            return Ok(this.solicitacaoService.ConsultarServicosEncerrados());
        }

        [HttpGet("pendentes")]
        public IActionResult ConsultarServicosPendentes()
        {
            return Ok(this.solicitacaoService.ConsultarServicosPendentes());
        }

        [HttpGet("pendentes/fretista")]
        public IActionResult ConsultarServicosPendentesFretista()
        {
            return Ok(this.solicitacaoService.ConsultarServicosPendentesFretista());
        }

        [HttpGet("encerradas/fretista")]
        public IActionResult ConsultarServicosEncerradosFretista()
        {
            return Ok(this.solicitacaoService.ConsultarServicosEncerradosFretista());
        }
    }
}

