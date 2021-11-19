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

    //onde a mágica do mapeamento e do token acontece
    public class PersonService : IPersonService
    {
        private readonly IPersonRepository personRepository;
        private readonly IMapper mapper;
        public PersonService(IPersonRepository personRepository, IMapper mapper)
        {
            this.personRepository = personRepository;
            this.mapper = mapper;
        }
        public List<PersonViewModel> Get()
        {
            IEnumerable<Person> _person = this.personRepository.GetAll();
            List<PersonViewModel> _personViewModels = mapper.Map<List<PersonViewModel>>(_person);

            return _personViewModels;
        }

        //Verificando se o usuário existe
        public PersonViewModel GetById(string id)
        {
            if (!Guid.TryParse(id, out Guid personId))
                throw new Exception("personID is not valid");

            Person _person = this.personRepository.Find(x => x.Id == personId && !x.IsDeleted); //verificando se o person existe
            if (_person == null)
            {
                throw new Exception("person not found");
            }
            return mapper.Map<PersonViewModel>(_person);
        }
        public PersonAuthenticateResponseViewModel Authenticate(PersonAuthenticateRequestViewModel person)
        {
            Person _person = this.personRepository.Find(x => !x.IsDeleted);
            if (_person == null)
                throw new Exception("Person not found");

            return new PersonAuthenticateResponseViewModel(mapper.Map<PersonViewModel>(_person));
        }

        public bool Post(PersonViewModel personViewModel)
        {
            Person _person = mapper.Map<Person>(personViewModel);
            this.personRepository.Create(_person);

            return true;
        }
    }
}
