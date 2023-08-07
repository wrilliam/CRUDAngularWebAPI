using Microsoft.EntityFrameworkCore;
using WebAPI.Config;

namespace WebAPI.Models
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

            modelBuilder.Entity<Departamento>()
                .HasOne(r => r.Responsavel)
                .WithMany(d => d.Departamentos)
                .HasForeignKey(r => r.IdResponsavel);
        }

        #endregion
    }
}
