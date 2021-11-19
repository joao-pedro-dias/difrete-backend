using AutoMapper;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using Template.Application.Interfaces;
using Template.Application.ViewModels;
using Template.Auth.Services;
using Template.Domain.Entities;
using Template.Domain.Interfaces;

namespace Template.Application.Services
{
    public class FretistaService : IFretistaService
    {
        private readonly IFretistaRepository fretistaRepository;
        private readonly IMapper mapper;
        public FretistaService(IFretistaRepository fretistaRepository, IMapper mapper)
        {
            this.fretistaRepository = fretistaRepository;
            this.mapper = mapper;
        }
        public List<FretistaViewModel> Get()
        {
            IEnumerable<Fretista> _fretista = this.fretistaRepository.GetAll();
            List<FretistaViewModel> _fretistaViewModels = mapper.Map<List<FretistaViewModel>>(_fretista);

            return _fretistaViewModels;
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
            return mapper.Map<FretistaViewModel>(_fretista);
        }
    }
}
