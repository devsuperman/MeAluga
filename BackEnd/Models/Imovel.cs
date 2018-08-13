using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MeAluga.Models
{
    public class Imovel
    {

        [Key]
        public int Id { get; set; }
       
        [Display(Name = "Data de Registro")]
        public DateTime DataRegistro { get; set; } = System.DateTime.Now;
                
        public Endereco Endereco { get; set; }
        public ICollection<Contrato> Contratos {get;set;}
    }
}
