using System.ComponentModel.DataAnnotations;

namespace TarefasBackEnd.Models.ViewModels
{
    public class UsuarioLogin
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public string Senha { get; set; }
    }
}