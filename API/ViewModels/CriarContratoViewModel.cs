using System;
using MeAluga.Models;
using System.ComponentModel.DataAnnotations;

namespace MeAluga.ViewModels
{
    public class CriarContratoViewModel
    {
        [Required]
        public Locatario Locatario { get; set; }

        [Required]
        public int ImovelId { get; set; }

        [Required]
        public string DataDeInicio { get; set; }

        [Required]
        public int Duracao { get; set; } //Em Meses

        [Required]
        public decimal ValorDoAluguel { get; set; }
    }
    
}