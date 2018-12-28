using System;
using API.Models;
using System.ComponentModel.DataAnnotations;

namespace API.ViewModels
{
    public class CriarContratoVM
    {        
        public Pessoa Locatario { get; set; }

        [Required, Display(Name = "Apartamento")]
        public string ApartamentoId { get; set; }

        [Required, Display(Name = "Data de Início"), DataType(DataType.Date)]
        public DateTime DataDeInicio { get; set; }

        [Required, Display(Name = "Duração do Contrato")]
        public int Duracao { get; set; } //Em Meses

        [Required, Display(Name = "Valor do Aluguel")]
        public decimal ValorDoAluguel { get; set; }
    }
    
}