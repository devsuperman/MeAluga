using System.ComponentModel.DataAnnotations;
using API.Extensions;

namespace API.Models
{    
    public class Pessoa 
    {   

        [Required, MaxLength(100)]
        public string Nome { get; set; }
        
        [Required, CPF, MaxLength(11)]
        public string CPF { get; set; }        
        
        [MaxLength(20)]
        public string RG { get; set; }

        [MaxLength(50)]
        public string Nacionalidade { get; set; } = "Brasileiro(a)";

        [MaxLength(50), Display(Name = "Profissão")]
        public string Profissao { get; set; }

        [Required, MaxLength(50), Display(Name = "Estado Civil")]
        public string EstadoCivil { get; set; }

        [MaxLength(20)]
        public string Telefone { get; set; }
      
        public bool InformacoesCompletas()
        {
            var nomePreenchido = string.IsNullOrWhiteSpace(this.Nome);            
            var cpfPreenchido = string.IsNullOrWhiteSpace(this.CPF);            
            var rgPreenchido = string.IsNullOrWhiteSpace(this.RG);            
            var telefonePreenchido = string.IsNullOrWhiteSpace(this.Telefone);            
            var nacionalidadePreenchido = string.IsNullOrWhiteSpace(this.Nacionalidade);            
            var profissaoPreenchido = string.IsNullOrWhiteSpace(this.Profissao);            
            var estadoCivilPreenchido = string.IsNullOrWhiteSpace(this.EstadoCivil);            

            var informacoesCompletas = 
                nomePreenchido && 
                cpfPreenchido && 
                rgPreenchido && 
                telefonePreenchido && 
                nacionalidadePreenchido && 
                profissaoPreenchido && 
                estadoCivilPreenchido;

            return informacoesCompletas;
        }
    }
}