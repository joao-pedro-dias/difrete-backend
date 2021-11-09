using System;
using System.Collections.Generic;
using System.Text;

namespace Template.Application.ViewModels
{
    public class UserAuthenticateRequestViewModel
    {
        //oq preciso para validar se o usuário existe ou não? Email e senha
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
