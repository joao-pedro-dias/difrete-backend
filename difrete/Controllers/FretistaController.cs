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
    public class FretistaController : ControllerBase
    {
        private readonly IFretistaService fretistaService;
        private readonly IAuthService authService;

        public FretistaController(IFretistaService fretistaService, IAuthService authService)
        {
            this.fretistaService = fretistaService;
            this.authService = authService;
        }

        [HttpGet("ativos")]
        public IActionResult GetAtivos()
        {
            return Ok(this.fretistaService.GetAtivos());
        }

        [HttpPatch("ativar")]
        public IActionResult Ativar()
        {
            this.fretistaService.Ativar();
            return Ok();
        }

        [HttpPatch("inativar")]
        public IActionResult Inativar()
        {
            this.fretistaService.Inativar();
            return Ok();
        }

        [HttpGet("logado")]
        public IActionResult GetById()
        {
            return Ok(this.fretistaService.GetById(authService.GetFretista().Id));
        }
    }
}

