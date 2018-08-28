using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MeAluga.Extensions;
using Microsoft.EntityFrameworkCore;

namespace MeAluga.Models
{
    public class Fiador
    {        
        [Key, ForeignKey("Garantia")]
        public int GarantiaId { get; set; }

        [Required, MaxLength(50)]
        public string Nome { get; set; }
        
        [Required, CPF, MaxLength(11)]
        public string CPF { get; set; }
                
        [MaxLength(20)]
        public string RG { get; set; }
        
        //TODO: Completar os dados do locatário

        [Display(Name = "Data de Registro")]
        public System.DateTime DataDeRegistro { get; set; } = System.DateTime.Now;
        
        public Garantia Garantia {get;set;}
        public Endereco Endereco { get; set; }
        
    }
}
