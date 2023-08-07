using Microsoft.EntityFrameworkCore;
using WebAPI.Config;

namespace WebAPI.Models
{
    public class Contexto : DbContext
    {
        #region Atributos
        public DbSet<Pessoa> Pessoas { get; set; }
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
