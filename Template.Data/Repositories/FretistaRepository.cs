using System;
using System.Collections.Generic;
using System.Linq;
using Template.Application.ViewModels;
using Template.Data.Context;
using Template.Domain.Entities;
using Template.Domain.Interfaces;

namespace Template.Data.Repositories
{
    public class FretistaRepository : Repository<Fretista>, IFretistaRepository
    {
        public FretistaRepository(TemplateContext context) : base(context) { }
        public IEnumerable<Fretista> GetAll()
        {
            return Query(x => !x.IsDeleted);
        }
        public List<FretistaViewModel> GetAllActives()
        {
            var query = from persons in _context.Persons
                        join users in _context.Users on persons.UserId equals users.Id
                        join fretistas in _context.Fretistas on users.Id equals fretistas.UserId
                        where fretistas.IsAtivo == true
                        select new { User = users, Person = persons, Fretista = fretistas };

            return query.Select(x => new FretistaViewModel(x.Fretista, x.User, x.Person))
                .ToList();
        }

    }
}
