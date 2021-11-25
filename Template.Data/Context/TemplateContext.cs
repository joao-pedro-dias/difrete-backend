using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Template.Data.Extensions;
using Template.Data.Mappings;
using Template.Domain.Entities;

namespace Template.Data.Context
{
    public class TemplateContext: DbContext
    {
        public TemplateContext(DbContextOptions<TemplateContext> option) : base(option) { } // constrututor

        #region "DBSets"

        public DbSet<User> Users { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Fretista> Fretistas { get; set; }
        public DbSet<StatusSolicitacao> StatusSolicitacoes { get; set; }
        public DbSet<Solicitacao> Solicitacoes { get; set; }

        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserMap());
            modelBuilder.ApplyConfiguration(new PersonMap());
            modelBuilder.ApplyConfiguration(new FretistaMap());
            modelBuilder.ApplyConfiguration(new StatusSolicitacaoMap());
            modelBuilder.ApplyConfiguration(new SolicitacaoMap());
            modelBuilder.ApplyGlobalConfigurations();

            base.OnModelCreating(modelBuilder);
        }
    }
}
