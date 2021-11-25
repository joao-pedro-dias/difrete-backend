using AutoMapper;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Linq;
using Template.Application.Interfaces;
using Template.Application.ViewModels;
using Template.Auth.Services;
using Template.Domain.Entities;
using Template.Domain.Interfaces;
using System.Data.Entity;

namespace Template.Application.Services
{
    public class FretistaService : IFretistaService
    {
        private readonly IFretistaRepository fretistaRepository;
        public FretistaService(IFretistaRepository fretistaRepository)
        {
            this.fretistaRepository = fretistaRepository;
        }

        public List<FretistaViewModel> GetAtivos()
        {
            var fretistas = fretistaRepository.GetAllActives();
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
