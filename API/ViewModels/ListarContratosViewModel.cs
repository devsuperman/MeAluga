using System;
using MeAluga.Models;
using System.ComponentModel.DataAnnotations;

namespace MeAluga.ViewModels
{
    public class ListarContratosViewModel
    {
        public ListarContratosViewModel(Contrato contrato)
        {
            this.Id = contrato.Id;
            this.Locatario = contrato.Locatario.Nome;
            this.Imovel = contrato.Imovel.Endereco.ToString();
            this.Situacao = contrato.EmAndamento() ? "Em Andamento" : "Encerrado";
        }

        public int Id { get; set; }

        public string Locatario { get; set; }

        public string Imovel { get; set; }

        public string Situacao { get; set; }
    }
    
}