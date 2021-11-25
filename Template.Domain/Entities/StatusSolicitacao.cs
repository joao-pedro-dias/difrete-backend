using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Template.Domain.Models;

namespace Template.Domain.Entities
{
    public class StatusSolicitacao : Entity
    {
        public long Id { get; set; }
        public string Descricao { get; set; }
        public bool IsStatusFinal { get; set; }
    }
}
