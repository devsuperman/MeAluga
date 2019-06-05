using System;
using MeAluga.Models;
using System.ComponentModel.DataAnnotations;

namespace MeAluga.ViewModels
{
    public class ListarImoveisViewModel
    {
        public ListarImoveisViewModel(Imovel imovel)
        {
            this.Id = imovel.Id;
            this.Endereco = imovel.Endereco.ToString();
            this.Situacao = imovel.Alugado() ? "Alugado" : "Disponível";
        }

        public int Id { get; set; }

        public string Endereco { get; set; }

        public string Situacao { get; set; }
    }
    
}