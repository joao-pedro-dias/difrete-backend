using System;
using System.Collections.Generic;
using System.Text;
using Template.Data.Context;
using Template.Domain.Entities;
using Template.Domain.Interfaces;

namespace Template.Data.Repositories
{
    public class PersonRepository : Repository<Person>, IPersonRepository
    {
        public PersonRepository(TemplateContext context) : base(context) { }
        public IEnumerable<Person> GetAll()
        {
            return Query(x => !x.IsDeleted);
        }
    }
}
