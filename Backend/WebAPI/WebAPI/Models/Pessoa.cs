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
        [Required]
        public string Nome { get; set; }
        [Column("Apelido")]
        [Required]
        public string Apelido { get; set; }
        [Column("Tipo")]
        [Required]
        public string Tipo { get; set; }
        [Column("Documento")]
        [Required]
        public string Documento { get; set; }
        [Column("Endereco")]
        [Required]
        public string Endereco { get; set; }
        [Column("DataCriacao")]
        public DateTime DataCriacao { get; set; } = DateTime.UtcNow;
        [Column("DataAtualizacao")]
        public DateTime DataAtualizacao { get; set; } = DateTime.UtcNow;

        public ICollection<Departamento> Departamentos { get; set; }
    }
}
