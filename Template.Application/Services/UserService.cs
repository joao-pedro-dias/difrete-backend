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
using System.Linq;

namespace Template.Application.Services
{
    //onde a mágica do mapeamento e do token acontece
    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository;
        private readonly IMapper mapper;
        public UserService(IUserRepository userRepository, IMapper mapper)
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

        public bool Post(UserViewModel userViewModel)
        {
            //encriptografando a senha do usuário após método POST
            User _user = mapper.Map<User>(userViewModel);
            _user.Password = EncryptPassword(_user.Password);

            this.userRepository.Create(_user);

            return true;
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

            User _user = this.userRepository.Find(x => !x.IsDeleted && x.Email.ToLower() == user.Email.ToLower() //aqui nesta parte, deveria ir junto o LoginType. Mas ele deve estar embutido no token
            && user.Password.ToLower() == user.Password.ToLower());
            if (_user == null)
                throw new Exception("User not found");

            return new UserAuthenticateResponseViewModel (mapper.Map<UserViewModel>(_user), TokenService.GenerateToken(_user));
            //convertendo o objeto e gerando Token. Retornando parâmetro conforme "UserAuthenticateResponseViewModel.cs" >> public UserAuthenticateResponseViewModel(UserViewModel user, string token)
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
