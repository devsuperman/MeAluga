using System;
using System.ComponentModel.DataAnnotations;

namespace MeAluga.Models
{
    public class Garantia
    {        
        [Key]
        public int Id { get; set; }        
        
        public Locatario Fiador { get; set; }

        [Display(Name = "Valor do Caução")]
        public decimal? valorCaucao { get; set; }
    }
}