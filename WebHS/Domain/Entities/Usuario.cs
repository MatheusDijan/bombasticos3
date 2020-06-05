using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WebHS.Models.Enums;

namespace WebHS.Domain.Entities
{
    public class Usuario : ClasseBasica
    {
        public Usuario()
        {
            Usuarios = new List<Usuario>();
        }
        [Required(ErrorMessage = "Nome obrigatório")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "E-mail obrigatório")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage = "E-mail inválido")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Senha obrigatória")]
        public string Senha { get; set; }

        public TipoUsuario TipoUsuario { get; set; }

        public List<Usuario> Usuarios { get; set; }
    
}
}
