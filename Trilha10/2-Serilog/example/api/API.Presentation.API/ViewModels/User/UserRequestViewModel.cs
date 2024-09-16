using System;
using System.ComponentModel.DataAnnotations;
using PDG.Presentation.API.DataAnnotations;

namespace API.Presentation.API.ViewModels.User
{
    public class UserRequestViewModel 
    {
        [Required(ErrorMessage = "Nome é obrigatório", AllowEmptyStrings = false)]
        [StringLength(100, ErrorMessage = "Campo Nome suporta até 100 caracteres.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email é obrigatório", AllowEmptyStrings = false)]
        [StringLength(50, ErrorMessage = "Campo E-mail suporta até 50 caracteres.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Senha é obrigatório", AllowEmptyStrings = false)]
        [StringLength(20, ErrorMessage = "Campo Senha suporta até 20 caracteres.")]
        public string Password { get; set; }

        [Required(ErrorMessage = "CPF é obrigatório", AllowEmptyStrings = false)]
        [StringLength(10, ErrorMessage = "Campo Cpf suporta até 10 caracteres.")]
        public string Cpf { get; set; }

        [Required(ErrorMessage = "RG é obrigatório", AllowEmptyStrings = false)]
        [StringLength(10, ErrorMessage = "Campo RG suporta até 10 caracteres.")]
        public string Rg { get; set; }

        [Required(ErrorMessage = "Data de nascimento é obrigatório", AllowEmptyStrings = false)]
        [BirthdayValidation("Birth")]
        public DateTime Birth { get; set; }

        [Required(ErrorMessage = "Perfil é obrigatório", AllowEmptyStrings = false)]
        public int ProfileId { get; set; }
    }
}