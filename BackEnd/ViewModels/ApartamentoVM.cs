using System;
using API.Models;
using System.ComponentModel.DataAnnotations;

namespace API.ViewModels
{
    public class ApartamentoVM
    {
        public ApartamentoVM()
        {
            
        }
        
        public ApartamentoVM(Apartamento apartamento)
        {
            this.Id = apartamento.Id.ToString();
            this.Apelido = apartamento.Apelido;
            this.Endereco = apartamento.Endereco;
        }

        public string Id { get; set; }
        
        [Required, MaxLength(50)]
        public string Apelido { get; set; }

        [Required, MaxLength(200), Display(Name = "Endereço")]       
        public string Endereco { get; set; }
    }
    
}