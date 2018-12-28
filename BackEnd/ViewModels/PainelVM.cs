using System;
using System.Linq;
using API.Models;
using System.Collections.Generic;

namespace API.ViewModels
{
    public class PainelVM
    {
        public PainelVM(IList<Contrato> contratos)
        {   
            var hoje = DateTime.Today;

            this.QuantidadeDeContratosVencidos = contratos.Count(q => 
                q.Situacao == SituacaoDeContrato.EmAndamento &&
                q.DataDePrevisaoDeEncerramento <= hoje);

            this.QuantidadeDeAlugueisVencidos = contratos
                .Where(q => q.Situacao == SituacaoDeContrato.EmAndamento)
                .SelectMany(a => a.Alugueis) 
                .Count(a => a.Vencimento <= hoje);            

            this.TudoJoia = (QuantidadeDeAlugueisVencidos < 1) && (QuantidadeDeContratosVencidos < 1);
        }

        public int QuantidadeDeAlugueisVencidos { get; set; }
        public int QuantidadeDeContratosVencidos { get; set; }  
        public bool TudoJoia { get; set; }
    }
}