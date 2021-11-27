using System;
using System.Collections.Generic;
using System.Text;
using Template.Application.ViewModels;

namespace Template.Application.Interfaces
{
    public interface IFretistaService
    {
        FretistaViewModel GetById(string id);
        List<FretistaViewModel> GetAtivos();
        void Ativar();
        void Inativar();
        FretistaViewModel GetById(Guid Id);
    }
}
