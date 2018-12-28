using System;
using API.Models;
using System.ComponentModel.DataAnnotations;

namespace API.ViewModels
{
    public class ReciboVM
    {
        public ReciboVM()
        {
            
        }

        public ReciboVM(Aluguel aluguel, Contrato contrato)
        {
            this.NomeDoLocatario = contrato.Locatario.Nome;
            this.CPFDoLocatario = contrato.Locatario.CPF;
            this.EnderecoDoApartamento = contrato.Apartamento.Endereco;
            this.DataDeInicio = aluguel.Vencimento.ToShortDateString();
            this.DataDeFim = aluguel.Vencimento.AddMonths(1).ToShortDateString();
            this.ValorDoAluguel = contrato.ValorDoAluguel;    
        }
                
        public string NomeDoLocatario { get; set; }
        public string CPFDoLocatario { get; set; }
        public string EnderecoDoApartamento {get;set;}
        public string DataDeInicio { get; set; }
        public string DataDeFim { get; set; }
        public decimal ValorDoAluguel { get; set; }
    }
    
}