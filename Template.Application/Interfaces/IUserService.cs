using System;
using System.Collections.Generic;
using System.Text;
using Template.Application.ViewModels;

namespace Template.Application.Interfaces
{
    public interface IUserService
    {
        List<UserViewModel> Get();
        UserViewModel GetById(string id);
        UserAuthenticateResponseViewModel Authenticate(UserAuthenticateRequestViewModel user);
        bool Put(UserViewModel userViewModel);
        bool Delete(string id);
        UserAuthenticateResponseViewModel Post(UserViewModel userViewModel);
    }
}
