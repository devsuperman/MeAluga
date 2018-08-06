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


        public virtual Pessoa Locatario {get;set;}
        
        public virtual Imovel Imovel {get;set;}
        public virtual ICollection<Aluguel> Alugueis {get;set;}
        public virtual Garantia Garantia {get;set;}
        //TODO:  public ISituacaoDeContrato Situacao {get;set;}

    }
    
}
