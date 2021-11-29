using System;
using System.Collections.Generic;
using System.Text;

namespace Template.Domain.Models
{
    public class Entity
    {
        //Entidade :: Pessoa :: User
        public Guid Id { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateUpdated { get; set; }
        public bool IsDeleted { get; set; }
    }
}
