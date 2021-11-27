using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using Template.Application.Interfaces;
using Template.Application.ViewModels;
using Template.Domain.Entities;
using Template.Domain.Interfaces;
namespace Template.Application.Services
{
    public class FretistaService : IFretistaService
    {
        private readonly IFretistaRepository fretistaRepository;
        private readonly IAuthService authService;

        public FretistaService(IFretistaRepository fretistaRepository, IAuthService authService)
        {
            this.fretistaRepository = fretistaRepository;
            this.authService = authService;
        }

        public List<FretistaViewModel> GetAtivos()
        {
            var fretistas = fretistaRepository.GetAllActives(authService.GetPerson().Id);
            var q = authService.GetFretista();
            return fretistas;
        }

        //Verificando se o usuário existe
        public FretistaViewModel GetById(string id)
        {
            if (!Guid.TryParse(id, out Guid userId))
                throw new Exception("UserID is not valid");

            Fretista _fretista = this.fretistaRepository.Find(x => x.Id == userId && !x.IsDeleted); //verificando se o user existe
            if (_fretista == null)
            {
                throw new Exception("User not found");
            }
            return new FretistaViewModel(_fretista);
        }

        public void Ativar()
        {
            var fretista = fretistaRepository.Find(x => x.UserId == authService.GetUser().Id);
            fretista.IsAtivo = true;
            fretistaRepository.Update(fretista);
        }

        public void Inativar()
        {
            var fretista = fretistaRepository.Find(x => x.UserId == authService.GetUser().Id);
            fretista.IsAtivo = false;
            fretistaRepository.Update(fretista);
        }

        public FretistaViewModel GetById(Guid Id)
        {
            return fretistaRepository.Query(x => x.Id == Id).Select(x => new FretistaViewModel(x, x.User, x.User.Person)).FirstOrDefault();
        }
    }
}
