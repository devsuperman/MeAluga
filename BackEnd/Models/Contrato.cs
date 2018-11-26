using System;
using MeAluga.Extensions;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace MeAluga.Models
{
    public partial class Contrato
    {      
        public Contrato()
        {
            
        }

        public Contrato(int imovelId, Locatario locatario, string dataDeInicio, int duracao, decimal valorAluguel)
        {
            this.Locatario = locatario;
            this.ImovelId = imovelId;                        
            this.DataDeInicio = Convert.ToDateTime(dataDeInicio);            
            
            var datasInvalidas = (this.DataDeInicio <= this.DataDeTermino);
            
            if (datasInvalidas)            
                throw new ValidationException("Datas inválidas!");                        
    
            this.DataDeTermino = this.DataDeInicio.AddMonths(duracao);
            GerarAlugueis(valorAluguel);            
        }     

        [Key]
        public int Id { get; private set; }

        [ForeignKey("Locatario")]
        public int LocatarioId { get; private set; }

        [ForeignKey("Imovel")]
        public int ImovelId { get; private set; }
        
        [ForeignKey("Fiador")]
        public int? FiadorId { get; private set; }
                
        [Display(Name = "Data de Registro")]
        public System.DateTime DataDeRegistro {get; private set;} = System.DateTime.Now;


        [Required, Display(Name = "Início"), DataType(DataType.Date)]
        public DateTime DataDeInicio { get; private set; }


        [Required, Display(Name = "Término"), DataType(DataType.Date)]
        public DateTime DataDeTermino { get; private set; }


        [Display(Name = "Observação"), MaxLength(300)]
        public string Observacao { get; private set; }
        
        public decimal Valor
        {
            get => (Alugueis.Any() ?  Alugueis.FirstOrDefault().Valor : 0);            
        }

        public Locatario Locatario {get; private set;}        
        public Imovel Imovel {get; private set;}
        public Fiador Fiador {get; private set;}
        public ICollection<Aluguel> Alugueis {get; private set;} = new List<Aluguel>();
        

        public bool EmAndamento()
        {
            return this.Situacao() == SituacaoDeContrato.EmAndamento;
        }

        private SituacaoDeContrato Situacao(){
            
            var retorno = SituacaoDeContrato.EmAndamento;

            var contratoEmAndamento = (DateTime.Today >= this.DataDeInicio && DateTime.Today <= this.DataDeTermino);            

            if (!contratoEmAndamento)            
                return SituacaoDeContrato.Encerrado;            

            return retorno;
        }

        private void GerarAlugueis(decimal valorAluguel)
        {
            var esseMesTemAluguel = true;
            var diaDoMes = this.DataDeInicio;

            while (esseMesTemAluguel)
            {
                var aluguel = new Aluguel(diaDoMes, valorAluguel);
                this.Alugueis.Add(aluguel);

                diaDoMes = diaDoMes.AddMonths(1);

                esseMesTemAluguel = (diaDoMes.PrimeiroDiaDoMes() < this.DataDeTermino.PrimeiroDiaDoMes());                
            }

        }

         private enum SituacaoDeContrato{
            EmAndamento,
            Encerrado
        }

    }
    
}
