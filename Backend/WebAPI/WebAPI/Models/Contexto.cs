using Microsoft.EntityFrameworkCore;

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
    }
}
