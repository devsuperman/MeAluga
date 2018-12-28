using System;
using API.Models;
using System.ComponentModel.DataAnnotations;


namespace API.ViewModels
{
    public class PagamentoDeAluguelVM
    {
        public PagamentoDeAluguelVM()
        {
            
        }
        public PagamentoDeAluguelVM(Aluguel aluguel, Contrato contrato)
        {
            this.Id = aluguel.Id.ToString();
            this.Vencimento = aluguel.Vencimento;
            this.ContratoId = contrato.Id.ToString();
            this.NomeDoLocatario = contrato.Locatario.Nome;
            this.ValorDoAluguel = contrato.ValorDoAluguel;
        }

        public string Id { get; set; }

        public string ContratoId { get; set; }
        
        public string NomeDoLocatario { get; set; }
        public decimal? ValorDoAluguel { get; set; }        
        public DateTime Vencimento { get; set; }

        [Required, DataType(DataType.Date), Display(Name = "Data de Pagamento")]
        public DateTime? DataDePagamento { get; set; }

        [Required, DataType(DataType.Currency), Display(Name = "Valor Pago")]
        public decimal? ValorPago { get; set; }
        
        [Display(Name = "Observação"), MaxLength(300)]
        public string Observacao {get;set;}
    }
}