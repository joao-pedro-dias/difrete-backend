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
    }
}

