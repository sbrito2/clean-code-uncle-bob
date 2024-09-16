using System.ComponentModel.DataAnnotations;

namespace API.Presentation.API.ViewModels.Login
{
    public class LoginViewModel 
    {
        [Required(ErrorMessage = "Campo e-mail é obrigatório", AllowEmptyStrings = false)]
        [StringLength(50, ErrorMessage = "Campo Email suporta até 50 caracteres.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Campo senha é obrigatório", AllowEmptyStrings = false)]
        [StringLength(20, ErrorMessage = "Campo Senha suporta até 20 caracteres.")]
        public string Password { get; set; }
    }
}