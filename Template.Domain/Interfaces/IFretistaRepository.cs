using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Template.Application.ViewModels;
using Template.Domain.Entities;

namespace Template.Domain.Interfaces
{
    public interface IFretistaRepository : IRepository<Fretista>
    {
        IEnumerable<Fretista> GetAll();
        List<FretistaViewModel> GetAllActives();
    }
}
