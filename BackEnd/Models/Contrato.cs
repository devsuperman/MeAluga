using System;
using System.Linq;
using MongoDB.Bson;
using API.Extensions;
using System.Collections.Generic;

namespace API.Models
{
    public partial class Contrato
    {   
        private const string Duracao06Meses = "06 Meses";
        private const string Duracao01Ano = "01 Ano";

        public Contrato(Apartamento apartamento, Pessoa locatario, DateTime dataDeInicio, int duracao, decimal valorAluguel)
        {
            this.Locatario = locatario;
            this.Apartamento = apartamento;                                    
            this.DataDeInicio = dataDeInicio;            
            
            //Adiciono +1 porque se não o contrato acaba no dia do vencimento do último aluguel, quando na verdade o cara ainda tem um mês pra morar
            this.DataDePrevisaoDeEncerramento = this.DataDeInicio.AddMonths(duracao + 1); 

            this.ValorDoAluguel = valorAluguel;
            this.Duracao = (duracao == 6 ? Duracao06Meses : Duracao01Ano);
            GerarAlugueis(valorAluguel);            
        }     
        
        public ObjectId Id { get; private set; }                        
        public DateTime DataDeInicio { get; private set; }       
        public DateTime DataDePrevisaoDeEncerramento { get; private set; }        
        public DateTime? DataDeEncerramento { get; set; }
        public string Observacao { get; private set; }        
        public decimal ValorDoAluguel { get; private set; }
        
        public string Duracao { get; set; }
        public Pessoa Locatario {get; private set;}        
        public Pessoa Fiador {get; private set;}
        public PessoaJuridica PessoaJuridica {get; private set;}        
        public Apartamento Apartamento {get; private set;}
        public string Situacao { get; private set; } = SituacaoDeContrato.EmAndamento;
        public DateTime DataDeRegistro {get; private set;} = System.DateTime.Now;
        public IList<Aluguel> Alugueis {get; private set;} = new List<Aluguel>();
        

        private void GerarAlugueis(decimal valorAluguel)
        {
            var esseMesTemAluguel = true;
            var diaDoMes = this.DataDeInicio;
            var ultimoMesQueTemAluguel = this.DataDePrevisaoDeEncerramento.AddMonths(-1); // O último mês de contrato em que o morador está na casa, foi pago no mês anterior

            while (esseMesTemAluguel)
            {
                var aluguel = new Aluguel(diaDoMes);
                this.Alugueis.Add(aluguel);

                diaDoMes = diaDoMes.AddMonths(1);

                esseMesTemAluguel = (diaDoMes.PrimeiroDiaDoMes() < ultimoMesQueTemAluguel.PrimeiroDiaDoMes());                
            }

        }

        public void Encerrar()
        {   
            this.Situacao = SituacaoDeContrato.Encerrado;
            this.DataDeEncerramento = DateTime.Today;
        }

        public bool PodeImprimir()
        {            
            var fiadorNoJeito = (this.Fiador != null) && (this.Fiador.InformacoesCompletas());
            var locatarioNoJeito = this.Locatario.InformacoesCompletas();
            var pessoaJuridicaNoJeito = (this.PessoaJuridica != null) && (this.PessoaJuridica.InformacoesCompletas());            
                        
            return fiadorNoJeito && locatarioNoJeito && pessoaJuridicaNoJeito;
        }

        public bool PodeEditar() => this.Situacao.Equals(SituacaoDeContrato.EmAndamento);
        public bool Vencido() => (this.Situacao == SituacaoDeContrato.EmAndamento) && (this.DataDePrevisaoDeEncerramento <= DateTime.Today);

    }
    
}
