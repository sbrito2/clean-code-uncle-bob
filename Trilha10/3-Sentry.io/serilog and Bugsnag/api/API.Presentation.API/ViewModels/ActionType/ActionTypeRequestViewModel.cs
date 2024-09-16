using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace API.Presentation.API.ViewModels.ActionType
{
    public class ActionTypeRequestViewModel 
    {
        [StringLength(100, ErrorMessage = "Campo tipo suporta até 100 caracteres.")]
        [Required(ErrorMessage = "Campo tipo é obrigatório", AllowEmptyStrings = false)]
        public string Type { get; set; }

        [StringLength(300, ErrorMessage = "Campo descrição suporta até 300 caracteres.")]
        [Required(ErrorMessage = "Campo descrição é obrigatório", AllowEmptyStrings = false)]
        public string Description { get; set; }
    }
}