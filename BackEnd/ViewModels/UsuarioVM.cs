using System.ComponentModel.DataAnnotations;
using API.Extensions;
using API.Models;
using System;

namespace API.ViewModels
{
    public class UsuarioVM
    {
        public UsuarioVM()
        {
            
        }
        public UsuarioVM(Usuario usuario)
        {
            this.Id = usuario.Id.ToString();
            this.Nome = usuario.Nome;
            this.Email = usuario.Email;
        }

        public string Id { get; set; }

        [Required, MaxLength(50)]
        public string Nome { get; set; }

		[Required, MaxLength(50), EmailAddress]
		public string Email { get; set; }

    }
}