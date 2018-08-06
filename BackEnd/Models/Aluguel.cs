using System;
using System.ComponentModel.DataAnnotations;

namespace MeAluga.Models
{
    public class Aluguel
    {
        [Key]
        public int Id { get; set; }   
        
        [Required, Display(Name = "Vencimento"), DataType(DataType.Date)]
        public DateTime Vencimento { get; set; }
        
        
        [Required, Display(Name = "Valor"), DataType(DataType.Currency)]
        public decimal Valor { get; set; }
        
        //TODO: Modelar situação do pagamento do aluguel
        
        [Display(Name = "Valor Pago"), DataType(DataType.Currency)]
        public decimal? ValorPago { get; set; }
        
                
        [Display(Name = "Data de Pagamento"), DataType(DataType.Date)]
        public DateTime? DataPagamento { get; set; }


        [Display(Name = "Observação"), MaxLength(500)]
        public string observacao { get; set; }

        public Contrato Contrato {get;set;}
    }
}