namespace WebAPI.Models
{
    public class Pessoa
    {
        public int IdPessoa { get; set; }
        public string Tipo { get; set; }
        public string Documento { get; set; }
        public string Nome { get; set; }
        public string Apelido { get; set; }
        public string Endereco { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime DataAtualizacao { get; set; }
    }
}
