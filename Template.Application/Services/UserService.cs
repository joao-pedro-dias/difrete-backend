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
    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository;
        private readonly IMapper mapper;
        public UserService(IUserRepository userRepository, IPersonRepository personRepository, IMapper mapper)
        {
            this.userRepository = userRepository;
            this.mapper = mapper;
        }
        public List<UserViewModel> Get()
        {
            IEnumerable<User> _users = this.userRepository.GetAll();
            List<UserViewModel> _userViewModels = mapper.Map<List<UserViewModel>>(_users);

            return _userViewModels;
        }
        public UserAuthenticateResponseViewModel Post(UserViewModel userViewModel)
        {
            var foundUser = userRepository.Find(x => x.Email.ToLower() == userViewModel.Email.ToLower());

            if(foundUser != null)
            {
                throw new Exception("Email " + foundUser.Email + " já cadastrado");
            }

            //encriptografando a senha do usuário após método POST
            User _user = mapper.Map<User>(userViewModel);
            _user.Password = EncryptPassword(_user.Password);

            var createdUser = this.userRepository.Create(_user);
            createdUser.Person.User = null;
            createdUser.Password = null;

            if (createdUser.Fretista != null)
            {
                createdUser.Fretista.User = null;
            }

            return new UserAuthenticateResponseViewModel(mapper.Map<UserViewModel>(_user), TokenService.GenerateToken(_user));
        }

        //Verificando se o usuário existe
        public UserViewModel GetById(string id)
        {
            if (!Guid.TryParse(id, out Guid userId))
                throw new Exception("UserID is not valid");

            User _user = this.userRepository.Find(x => x.Id == userId && !x.IsDeleted); //verificando se o user existe
            if (_user == null)
            {
                throw new Exception("User not found");
            }
            return mapper.Map<UserViewModel>(_user);
        }
        public bool Put(UserViewModel userViewModel)
        {
            if (userViewModel.Id == Guid.Empty)
                throw new Exception("ID is invalid");
            User _user = this.userRepository.Find(x => x.Id == userViewModel.Id && !x.IsDeleted); //verificando se o user existe
            if (_user == null)
                throw new Exception("User not found");

            _user = mapper.Map<User>(userViewModel);
            _user.Password = EncryptPassword(_user.Password);

            this.userRepository.Update(_user);

            return true;
        }

        public bool Delete(string id)
        {
            if (!Guid.TryParse(id, out Guid userId))
                throw new Exception("UserID is not valid");

            User _user = this.userRepository.Find(x => x.Id == userId && !x.IsDeleted); //verificando se o user existe
            if (_user == null)
                throw new Exception("User not found");

            return this.userRepository.Delete(_user); ;
        }

        public UserAuthenticateResponseViewModel Authenticate(UserAuthenticateRequestViewModel user)
        {
            if (string.IsNullOrEmpty(user.Email) || string.IsNullOrEmpty(user.Password))
                throw new Exception("Email/Password are required");

            user.Password = EncryptPassword(user.Password);

            var _user = this.userRepository.FindActiveUser(user.Email, user.Password);
            if (_user == null)
                throw new Exception("User not found");

            return new UserAuthenticateResponseViewModel (mapper.Map<UserViewModel>(_user), TokenService.GenerateToken(_user));
        }

        private string EncryptPassword(string password)
        {
            HashAlgorithm sha = new SHA1CryptoServiceProvider();

            byte[] encryptedPassword = sha.ComputeHash(Encoding.UTF8.GetBytes(password));   

            StringBuilder stringBuilder = new StringBuilder();
            foreach (var caracter in encryptedPassword)
            {
                stringBuilder.Append(caracter.ToString("X2"));
            }

            return stringBuilder.ToString();
        }

    }
}
