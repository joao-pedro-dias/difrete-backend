﻿using System;
using System.Collections.Generic;
using System.Text;
using Template.Domain.Models;

namespace Template.Domain.Entities
{
    public class User: Entity
    {
        /*aqui vou criar meus atribtuos de user*/
        public string Name { get; set; }
        public string Email { get; set; }
    }
}
