using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebAPI.Models
{
    public class DepartamentoModel
    {
        public int IdDepartamento { get; set; }
        public string Nome { get; set; }
        public int IdResponsavel { get; set; }
    }
}
