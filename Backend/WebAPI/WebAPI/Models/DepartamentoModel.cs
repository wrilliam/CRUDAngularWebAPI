using System.ComponentModel.DataAnnotations;

namespace WebAPI.Models
{
    public class DepartamentoModel
    {
        public int IdDepartamento { get; set; }
        [Required(ErrorMessage = "Insira o nome.")]
        public string? Nome { get; set; }
        [Required(ErrorMessage = "Insira o ID do responsável.")]
        [Range(0, int.MaxValue, ErrorMessage = "O ID precisa ser maior que 0.")]
        public int IdResponsavel { get; set; }
    }
}
