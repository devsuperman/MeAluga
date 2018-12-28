using System;
using API.Models;

namespace API.ViewModels
{
    public class AluguelVM
    {
        public AluguelVM(Contrato contrato, Aluguel aluguel)
        {
            Id = aluguel.Id;
            Vencimento = aluguel.Vencimento;
            Valor = contrato.ValorDoAluguel;
            Locatario = contrato.Locatario.Nome;
            Situacao = aluguel.Situacao;
            
            Atrasado = aluguel.Vencido();
        }

        public string Id { get; set; }
        public decimal Valor { get; set; }
        public DateTime Vencimento { get; set; }
        public string Locatario { get; set; }
        public string Situacao { get; set; }
        public bool Atrasado { get; set; }
    }
}