﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Template.Domain.Models;

namespace Template.Domain.Entities
{
    public class Person: Entity
    {
        [ForeignKey("User")]
        public Guid UserId;

        //Minha entidade Pessoa
        //Entidade :: Pessoa :: User
        public string Name { get; set; }
        public string Cpf { get; set; }
        public string Celular { get; set; }
        public User User { get; set; }
    }
}
