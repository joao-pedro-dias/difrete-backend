using System;
using System.Collections.Generic;
using System.Linq;
using Template.Application.Interfaces;
using Template.Application.ViewModels;
using Template.Data.Context;
using Template.Domain.Entities;
using Template.Domain.Enums;
using Template.Domain.Interfaces;

namespace Template.Data.Repositories
{
    public class FretistaRepository : Repository<Fretista>, IFretistaRepository
    {
        public FretistaRepository(TemplateContext context) : base(context) {
        }

        public IEnumerable<Fretista> GetAll()
        {
            return Query(x => !x.IsDeleted);
        }
        public List<FretistaViewModel> GetAllActives(Guid personId)
        {
            var query = from persons in _context.Persons
                        join users in _context.Users on persons.UserId equals users.Id
                        join fretistas in _context.Fretistas on users.Id equals fretistas.UserId
                        let solicitacoes = _context.Solicitacoes.Where(x => x.Status.Descricao == StatusSolicitacaoEnum.PENDENTE.ToString() && x.PersonId == personId && x.FretistaId == fretistas.Id).ToList()
                        where fretistas.IsAtivo == true && solicitacoes.Count() == 0
                        select new { User = users, Person = persons, Fretista = fretistas };

            return query.Select(x => new FretistaViewModel(x.Fretista, x.User, x.Person)).ToList();
        }

    }
}
