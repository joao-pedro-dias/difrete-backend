using System;
using System.Collections.Generic;
using System.Text;
using Template.Application.ViewModels;
using Template.Domain.Entities;

namespace Template.Application.Interfaces
{
    public interface IAuthService
    {
        UserViewModel GetUser();
        Person GetPerson();
        Fretista GetFretista();
    }
}
