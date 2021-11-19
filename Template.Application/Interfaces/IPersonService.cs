using System;
using System.Collections.Generic;
using System.Text;
using Template.Application.ViewModels;

namespace Template.Application.Interfaces
{
    public interface IPersonService
    {
        List<PersonViewModel> Get();
        PersonViewModel GetById(string id);
        PersonAuthenticateResponseViewModel Authenticate(PersonAuthenticateRequestViewModel person);
        bool Post(PersonViewModel personViewModel);

    }
}
