using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Template.Domain.Models;

namespace Template.Domain.Entities
{
    public class Solicitacao : Entity
    {
        [ForeignKey("Person")]
        public Guid PersonId;
        [ForeignKey("Fretista")]
        public Guid FretistaId;
        [ForeignKey("Status")]
        public long StatusId;

        public Fretista Fretista { get; set; }
        public Person Person { get; set; }
        public StatusSolicitacao Status { get; set; }
    }
}
