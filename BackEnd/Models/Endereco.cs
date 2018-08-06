using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace MeAluga.Models
{
    [Owned]
    public class Endereco
    {   
        [MaxLength(10)]
        public string CEP { get; set; }

        [MaxLength(50)]
        public string Rua { get; set; }

        [Display(Name = "Número"), MaxLength(10)]
        public string Numero { get; set; }

        [MaxLength(50)]
        public string Bairro { get; set; }

        [MaxLength(100)]
        public string Complemento { get; set; }

        [MaxLength(50)]
        public string Cidade { get; set; }

        [MaxLength(50)]
        public string Estado { get; set; }
        
        public override string ToString()
        {
            return $"{Rua}, {Numero}, {Bairro}, {Complemento}, {CEP}, {Cidade} - {Estado}";
        }
    }
}
