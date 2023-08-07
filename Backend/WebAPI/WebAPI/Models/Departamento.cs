﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebAPI.Models
{
    public class Departamento
    {
        [Key]
        [Column("IdDepartamento")]
        public int IdDepartamento { get; set; }
        [Column("Nome")]
        [Required]
        public string Nome { get; set; }
        [Column("IdResponsavel")]
        [Required]
        public int IdResponsavel { get; set; }
        public virtual Pessoa Responsavel { get; set; }
    }
}
