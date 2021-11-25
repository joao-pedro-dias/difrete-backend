using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Template.Domain.Models;

namespace Template.Domain.Entities
{
    public class Fretista : Entity
    {
        [ForeignKey("User")]
        public Guid UserId;
        public bool IsAtivo { get; set; }
        public string RazaoSocial { get; set; }
        public string Cnpj { get; set; }
        public string Rntrc { get; set; }
        public User User { get; set; }
    }
}
