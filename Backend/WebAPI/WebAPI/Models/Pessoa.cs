using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI.Models
{
    public class Pessoa
    {
        [Key]
        [Column("IdPessoa")]
        public int IdPessoa { get; set; }
        [Column("Nome")]
        public string Nome { get; set; }
        [Column("Apelido")]
        public string Apelido { get; set; }
        [Column("Tipo")]
        public string Tipo { get; set; }
        [Column("Documento")]
        public string Documento { get; set; }
        [Column("Endereco")]
        public string Endereco { get; set; }
        [Column("DataCriacao")]
        public DateTime DataCriacao { get; set; } = DateTime.UtcNow;
        [Column("DataAtualizacao")]
        public DateTime DataAtualizacao { get; set; } = DateTime.UtcNow;
    }
}
