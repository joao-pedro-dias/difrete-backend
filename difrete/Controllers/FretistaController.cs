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

        public FretistaController(IFretistaService fretistaService)
        {
            this.fretistaService = fretistaService;
        }

        [HttpGet("ativos")]
        public IActionResult GetAtivos()
        {
            return Ok(this.fretistaService.GetAtivos());
        }
    }
}

