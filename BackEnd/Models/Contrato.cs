using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MeAluga.Models
{
    public class Contrato
    {      
        [Key]
        public int Id { get; set; }
                
        [Display(Name = "Data de Registro")]
        public System.DateTime DataRegistro {get;set;} = System.DateTime.Now;


        [Required, Display(Name = "Início"), DataType(DataType.Date)]
        public DateTime Inicio { get; set; }


        [Required, Display(Name = "Término"), DataType(DataType.Date)]
        public DateTime Termino { get; set; }


        [Display(Name = "Observação"), MaxLength(300)]
        public string Observacao { get; set; }


        public Locatario Locatario {get;set;}        
        public Imovel Imovel {get;set;}
        public Garantia Garantia {get;set;}
        public ICollection<Aluguel> Alugueis {get;set;} = new List<Aluguel>();
        //TODO:  public ISituacaoDeContrato Situacao {get;set;}

    }
    
}
