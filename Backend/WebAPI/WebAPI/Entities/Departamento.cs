﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebAPI.Entities
{
    public class Departamento
    {
        [Key]
        [Column("IdDepartamento")]
        public int IdDepartamento { get; set; }
        [Column("Nome")]
        [Required]
        public string? Nome { get; set; }
        [Column("IdResponsavel")]
        [Required]
        public int IdResponsavel { get; set; }
        [ForeignKey("IdResponsavel")]
        public virtual Pessoa? Responsavel { get; set; }
        [Column("DataCriacao")]
        public DateTime DataCriacao { get; set; }
        [Column("DataAtualizacao")]
        public DateTime DataAtualizacao { get; set; }
    }
}
