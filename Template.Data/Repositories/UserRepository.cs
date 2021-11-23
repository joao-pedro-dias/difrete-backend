using System;
using System.Collections.Generic;
using System.Text;
using Template.Data.Context;
using Template.Domain.Entities;
using Template.Domain.Interfaces;
using System.Linq;

namespace Template.Data.Repositories
{
    public class UserRepository: Repository<User>, IUserRepository
    {
        public UserRepository(TemplateContext context) : base(context) { }
        public IEnumerable<User> GetAll()
        {
            return Query(x => !x.IsDeleted);
        }

        public User FindActiveUser(string email, string password)
        {
            var query = from persons in _context.Persons
                        join users in _context.Users on persons.UserId equals users.Id
                        let fretistas = _context.Fretistas.Where(x => x.UserId == users.Id).FirstOrDefault()
                        where persons.UserId == users.Id
                            && (fretistas == null || fretistas.UserId == users.Id)
                            && users.IsDeleted == false && users.Email.ToLower() == email.ToLower() && users.Password == password
                        select new { User = users, Person = persons, Fretista = fretistas };

            if(query.Count() == 0)
            {
                throw new Exception("Usuário e/ou senha incorretos");
            }

            var result = query.First();

            var user = result.User;
            user.Person = result.Person;
            user.Person.User = null;

            user.Fretista = result.Fretista;
            if(user.Fretista != null)
            {
                user.Fretista.User = null;
            }
            return user;
        }
    }
}
