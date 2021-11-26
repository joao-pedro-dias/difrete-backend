using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
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
    }
}
