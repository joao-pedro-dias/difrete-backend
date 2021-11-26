using Microsoft.AspNetCore.Http;
using Template.Application.Interfaces;
using Template.Application.ViewModels;
using Template.Domain.Entities;
using Template.Domain.Interfaces;

namespace Template.Application.Services
{
    public class AuthService : IAuthService
    {
        private readonly IPersonRepository personRepository;
        private readonly IFretistaRepository fretistaRepository;
        private readonly IHttpContextAccessor httpContextAccessor;
        public AuthService(IFretistaRepository fretistaRepository, IPersonRepository personRepository, IHttpContextAccessor httpContextAccessor)
        {
            this.fretistaRepository = fretistaRepository;
            this.httpContextAccessor = httpContextAccessor;
            this.personRepository = personRepository;
        }

        public UserViewModel GetUser()
        {
            return (UserViewModel) httpContextAccessor.HttpContext.Items["User"];
        }

        public Fretista GetFretista()
        {

            return fretistaRepository.Find(x => x.UserId.Equals(GetUser().Id));
        }

        public Person GetPerson()
        {
            return personRepository.Find(x => x.UserId.Equals(GetUser().Id));
        }
    }
}
