﻿using System;
using System.Collections.Generic;
using System.Text;
using Template.Domain.Models;

namespace Template.Domain.Entities
{
    public class Person: Entity
    {
        public string Name { get; set; }
        public string Cpf { get; set; }
        public string Celular { get; set; }
    }
}
