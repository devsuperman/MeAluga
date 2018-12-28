using System;
using MongoDB.Bson;

namespace API.Models
{
    public class Aluguel
    {        
        public Aluguel(DateTime vencimento)
        {
            this.Vencimento = vencimento;        
        }
                
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public DateTime Vencimento { get; private set; }        
        public string Situacao { get; private set; } = SituacaoDeAluguel.EmAberto;


        public DateTime? DataDePagamento { get; private set; }        
        public decimal? ValorPago { get; private set; }        
        public string Observacao { get; private set; }

        //Não estou utilizando esse método :(
        public void EfetuarPagamento(DateTime dataDePagamento, decimal valorPago, string observacao)
        {
            this.DataDePagamento = dataDePagamento;
            this.ValorPago = valorPago;
            this.Observacao = observacao;
            this.Situacao = SituacaoDeAluguel.Pago;
        }

        public bool Pago() => this.DataDePagamento.HasValue;
        public bool Vencido() => (this.Situacao == SituacaoDeAluguel.EmAberto) && (Vencimento <= DateTime.Today);
    }
}