using System;
using MeAluga.Models;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace MeAluga.ViewModels
{
    public class ContratoVM
    {
        public ContratoVM(Contrato contrato)
        {
            this.Id = contrato.Id;
            this.Locatario = contrato.Locatario;
            this.Imovel = contrato.Imovel;
            this.Alugueis = contrato.Alugueis;
        }
        public int Id { get; set; }
        public Locatario Locatario { get; set; }
        public Imovel Imovel { get; set; }
        public ICollection<Aluguel> Alugueis {get;set;}
        
        
    }
    
}