
using System.ComponentModel.DataAnnotations;

namespace API.Models
{    
    public class PessoaJuridica
    {
        [Required, MaxLength(100), Display(Name = "Nome Fantasia")]        
        public string NomeFantasia { get; set; }                        

        [Required, MaxLength(20)]        
        public string CNPJ { get; set; }        

        [Required, MaxLength(100), Display(Name = "Razão Social")]        
        public string RazaoSocial { get; set; }        
        
        public bool InformacoesCompletas()
        {
            var nomeFantasiaPreenchido = string.IsNullOrWhiteSpace(this.NomeFantasia);            
            var cnpjPreenchido = string.IsNullOrWhiteSpace(this.CNPJ);            
            var razaoSocialPreenchido = string.IsNullOrWhiteSpace(this.RazaoSocial);                        

            var informacoesCompletas = 
                nomeFantasiaPreenchido && 
                cnpjPreenchido && 
                razaoSocialPreenchido;

            return informacoesCompletas;
        }
    }
}