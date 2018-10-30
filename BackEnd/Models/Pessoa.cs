using System;
using System.ComponentModel.DataAnnotations;
using MeAluga.Extensions;

namespace MeAluga.Models
{    
    public abstract class Pessoa 
    {
        [Required, MaxLength(50)]
        public string Nome { get; set; }
        
        [Required, CPF, MaxLength(11)]
        public string CPF { get; set; }        
        
        [MaxLength(20)]
        public string RG { get; set; }

        [MaxLength(50)]
        public string Nacionalidade { get; set; }

        [MaxLength(50)]
        public string Profissao { get; set; }

        [Required, MaxLength(50)]
        public string EstadoCivil { get; set; }

        [MaxLength(15)]
        public string Telefone { get; set; }
    }
}