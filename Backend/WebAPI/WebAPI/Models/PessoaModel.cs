using System.ComponentModel.DataAnnotations;

namespace WebAPI.Models
{
    public class PessoaModel
    {
        public int IdPessoa { get; set; }
        [Required(ErrorMessage = "Insira o nome.")]
        public string? Nome { get; set; }
        public string? Apelido { get; set; }
        [Required(ErrorMessage = "Insira o tipo. PF ou PJ?")]
        public string? Tipo { get; set; }
        [Required(ErrorMessage = "Insira o documento. CPF ou CNPJ.")]
        public string? Documento { get; set; }
        [Required(ErrorMessage = "Insira o endereço.")]
        public string? Endereco { get; set; }
    }
}
