using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace MeAluga.Models
{
    public class Imovel
    {

        [Key]
        public int Id { get; set; }
       
        [Display(Name = "Data de Registro")]
        public DateTime DataDeRegistro { get; set; } = System.DateTime.Now;

        public Endereco Endereco { get; set; }
        public ICollection<Contrato> Contratos {get;set;} = new List<Contrato>();

        public bool Alugado()
        {
            return this.Contratos.Any(a => a.EmAndamento());
        }
        
        public bool Disponivel()
        {
            return !this.Alugado();
        }
    }
}
