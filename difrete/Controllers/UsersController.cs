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
<<<<<<< HEAD
<<<<<<< HEAD
    [ApiController, Authorize]    
=======
    [ApiController, Authorize] //colocan    
>>>>>>> 976aa890d6b08c890828079776276d8d0483fb54
=======
    [ApiController, Authorize] //colocan    
>>>>>>> 976aa890d6b08c890828079776276d8d0483fb54

    public class UsersController : ControllerBase
    {
        private readonly IUserService userService;
        
        public UsersController(IUserService userService)
        {
            this.userService = userService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(this.userService.Get());
        }

        [HttpPost, AllowAnonymous] //com o AllowAnonymous conseguimos liberar a API para ser pública
        public IActionResult Post(UserViewModel userViewModel)
        {

            return Ok(this.userService.Post(userViewModel));
        }

        [HttpGet("{id}")] //apenas para teste. A API precisa ser privada
        public IActionResult GetById(string id)
        {
            return Ok(this.userService.GetById(id));
        }

        [HttpPut]
        public IActionResult Put(UserViewModel userViewModel)
        {
            return Ok(this.userService.Put(userViewModel));
        }
        [HttpDelete]
        public IActionResult Delete()
        {
            string _userId = TokenService.GetValueFromClaim(HttpContext.User.Identity, ClaimTypes.NameIdentifier);
            return Ok(this.userService.Delete(_userId));
        }

        [HttpPost("authenticate"), AllowAnonymous] //com o AllowAnonymous conseguimos liberar a API para ser pública
        public IActionResult Authenticate(UserAuthenticateRequestViewModel userViewModel)
        {
            return Ok(this.userService.Authenticate(userViewModel));
        }
    }
}

