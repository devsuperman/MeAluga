﻿using MeAluga.Extensions;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MeAluga.Models
{
    public class Locatario
    {        
        [Key]
        public int Id { get; set; }


        [Required, MaxLength(50)]
        public string Nome { get; set; }

        
        [Required, CPF, MaxLength(11)]
        public string CPF { get; set; }
        
        
        [Required, MaxLength(20)]
        public string RG { get; set; }
        

        //TODO: Completar os dados do locatário

        [Display(Name = "Data de Registro")]
        public System.DateTime DataDeRegistro { get; set; } = System.DateTime.Now;
        
        public ICollection<Contrato> Contratos {get;set;} = new List<Contrato>();
        
    }
}
