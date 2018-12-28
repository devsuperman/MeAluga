using System;
using MongoDB.Bson;

namespace API.Models
{
    public class Apartamento
    {           
        public Apartamento(string endereco, string apelido)
        {
            Endereco = endereco;
            Apelido = apelido;
        }

        public ObjectId Id { get; private set; }        
        public string Apelido { get; private set; }           
        public string Endereco { get; private set; }
        public string Situacao { get; private set; } = SituacaoDeApartamento.Desocupado;

        public bool Alugado() => this.Situacao.Equals(SituacaoDeApartamento.Alugado);

        public void Desocupar() => this.Situacao = SituacaoDeApartamento.Desocupado;
    }
}
