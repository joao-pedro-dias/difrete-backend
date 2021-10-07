using System;
using System.Collections.Generic;
using System.Text;

namespace Template.Domain.Entities
{
    public class User
    {
        /*aqui vou criar meus atribtuos de user*/
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
    }
}
