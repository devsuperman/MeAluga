using System;
using MongoDB.Bson;

namespace API.Models
{
    public class Usuario
	{	
		public Usuario(string nome, string email)
		{
			GerarNovaHash();
            Nome = nome;
            Email = email;
		}

        public ObjectId Id { get; private set; }
        public string Nome { get; private set; }
		public string Email { get; private set; }
		public string Hash {get; private set; } 
		public bool HashUtilizado {get; private set;}
        public bool ehAdmin { get; private set; }
		public string Senha { get; private set; } = Guid.NewGuid().ToString();

        public void UtilizarHash() => this.HashUtilizado = true;
        
        public void AlterarSenha(string senhaCriptografada) => this.Senha = senhaCriptografada;

        public void GerarNovaHash()
        {
            this.Hash = Guid.NewGuid().ToString();
            this.HashUtilizado = false;
        }        
    }
}