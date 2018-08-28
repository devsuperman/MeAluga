using System;
using MeAluga.Extensions;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MeAluga.Models
{
    public partial class Contrato
    {      
        public Contrato()
        {
            
        }

        public Contrato(int imovelId, Locatario locatario, DateTime dataDeInicio, DateTime dataDeTermino, decimal valorAluguel)
        {
            this.Locatario = locatario;
            this.ImovelId = imovelId;            
            this.DataDeInicio = dataDeInicio;
            this.DataDeTermino = dataDeTermino;
            
            var datasInvalidas = (this.DataDeInicio <= this.DataDeTermino);
            
            if (datasInvalidas)            
                throw new ValidationException("Datas inválidas!");                        

            GerarAlugueis(valorAluguel);            
        }     

        [Key]
        public int Id { get; set; }

        [ForeignKey("Locatario")]
        public int LocatarioId { get; set; }

        [ForeignKey("Imovel")]
        public int ImovelId { get; set; }
                
        [Display(Name = "Data de Registro")]
        public System.DateTime DataDeRegistro {get;set;} = System.DateTime.Now;


        [Required, Display(Name = "Início"), DataType(DataType.Date)]
        public DateTime DataDeInicio { get; set; }


        [Required, Display(Name = "Término"), DataType(DataType.Date)]
        public DateTime DataDeTermino { get; set; }


        [Display(Name = "Observação"), MaxLength(300)]
        public string Observacao { get; set; }


        public Locatario Locatario {get;set;}        
        public Imovel Imovel {get;set;}
        public Garantia Garantia {get;set;}
        public ICollection<Aluguel> Alugueis {get;set;} = new List<Aluguel>();
        
        public SituacaoDeContrato Situacao(){
            
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
                esseMesTemAluguel = (diaDoMes.PrimeiroDiaDoMes() <= this.DataDeTermino.PrimeiroDiaDoMes());
            }

        }

         public enum SituacaoDeContrato{
            EmAndamento,
            Encerrado
        }

    }
    
}
