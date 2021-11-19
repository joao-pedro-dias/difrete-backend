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

    public class PersonsController : ControllerBase
    {
        private readonly IPersonService personService;

        public PersonsController(IPersonService personService)
        {
            this.personService = personService;
        }

        [HttpPost, AllowAnonymous] //com o AllowAnonymous conseguimos liberar a API para ser pública
        public IActionResult Post(PersonViewModel personViewModel)
        {

            return Ok(this.personService.Post(personViewModel));

        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(this.personService.Get());
        }

        [HttpGet("{id}")] //buscando pelo ID do cliente e passando parâmetro na API
        public IActionResult GetById(string id)
        {
            return Ok(this.personService.GetById(id));
        }

        [HttpPost("authenticate"), AllowAnonymous] //buscar o cliente no sistema
        public IActionResult Authenticate(PersonAuthenticateRequestViewModel personVieweModel)
        {
            return Ok(this.personService.Authenticate(personVieweModel));
        }

    }
}

