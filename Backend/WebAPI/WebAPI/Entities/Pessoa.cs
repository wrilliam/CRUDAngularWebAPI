using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI.Entities
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
        public DateTime DataCriacao { get; set; }
        [Column("DataAtualizacao")]
        public DateTime DataAtualizacao { get; set; }
    }
}
