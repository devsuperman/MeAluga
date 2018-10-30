using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MeAluga.Models
{
    public class Locatario : Pessoa
    {        
        [Key]
        public int Id { get; set; }

        [Display(Name = "Data de Registro")]
        public System.DateTime DataDeRegistro { get; set; } = System.DateTime.Now;
        
        public ICollection<Contrato> Contratos {get;set;} = new List<Contrato>();        
        
    }
}
