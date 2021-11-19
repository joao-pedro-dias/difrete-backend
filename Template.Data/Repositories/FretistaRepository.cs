using System;
using System.Collections.Generic;
using System.Text;
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
    }
}
