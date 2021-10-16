using System;
using System.Collections.Generic;
using System.Text;
using Template.Application.Enum;
using Template.Domain.Entities;

namespace Template.Application.ViewModels
{
    public class UserViewModel
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public Person Person { get; set; }
        public LoginType LoginType { get; set; }
    }
}
