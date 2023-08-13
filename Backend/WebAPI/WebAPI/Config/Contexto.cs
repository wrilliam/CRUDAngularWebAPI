using Microsoft.EntityFrameworkCore;
using WebAPI.Entities;

namespace WebAPI.Config
{
    public class Contexto : DbContext
    {
        #region Atributos

        public DbSet<Pessoa> Pessoas { get; set; }
        public DbSet<Departamento> Departamentos { get; set; }

        #endregion

        #region Construtor
        public Contexto(DbContextOptions<Contexto> opcoes) : base(opcoes)
        {
        }
        #endregion

        #region Métodos

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PessoaConfig());
            base.OnModelCreating(modelBuilder);
        }

        #endregion
    }
}
