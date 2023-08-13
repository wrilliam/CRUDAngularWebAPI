using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI.Models
{
    public class PessoaModel
    {
        public int IdPessoa { get; set; }
        public string Nome { get; set; }
        public string Apelido { get; set; }
        public string Tipo { get; set; }
        public string Documento { get; set; }
        public string Endereco { get; set; }
    }
}
