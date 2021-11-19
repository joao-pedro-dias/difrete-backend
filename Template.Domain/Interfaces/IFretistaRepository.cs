using System;
using System.Collections.Generic;
using System.Text;
using Template.Domain.Entities;

namespace Template.Domain.Interfaces
{
    public interface IFretistaRepository : IRepository<Fretista>
    {
        IEnumerable<Fretista> GetAll();
    }
}
