using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MeAluga.Models
{
    public class Garantia
    {        
        [Key, ForeignKey("Contrato")]
        public int ContratoId { get; set; }        
        
        [Display(Name = "Valor do Caução")]
        public decimal? valorCaucao { get; set; }
        
        [Display(Name = "Data de Registro")]
        public System.DateTime DataDeRegistro { get; set; } = System.DateTime.Now;

        public Fiador Fiador { get; set; }
        public Contrato Contrato { get; set; }
    }
}