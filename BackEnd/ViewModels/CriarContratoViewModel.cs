using System;
using MeAluga.Models;
using System.ComponentModel.DataAnnotations;

namespace MeAluga.ViewModels
{
    public class CriarContratoViewModel
    {
        public Locatario Locatario { get; set; }

        [Required]
        public int ImovelId { get; set; }

        [Required]
        public DateTime DataDeInicio { get; set; }

        [Required]
        public DateTime DataDeTermino { get; set; }

        [Required]
        public decimal ValorDoAluguel { get; set; }
    }
    
}