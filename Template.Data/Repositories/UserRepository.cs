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
                        from fretistas in _context.Fretistas
                        join users in _context.Users on persons.UserId equals users.Id
                        where users.IsDeleted == false && users.Email.ToLower() == email.ToLower() && users.Password == password
                            && (fretistas == null || fretistas.UserId == users.Id)
                        select new { User = users, Person = persons, Fretista = fretistas };

            var result = query.First();

            var user = result.User;
            user.Person = result.Person;
            user.Person.User = null;

            user.Fretista = result.Fretista;
            user.Fretista.User = null;

            return user;
        }
    }
}
