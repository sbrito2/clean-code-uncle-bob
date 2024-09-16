using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace API.Presentation.API.ViewModels.ResourceType
{
    public class ResourceTypeRequestViewModel 
    {
        [Required(ErrorMessage = "Tipo é obrigatório", AllowEmptyStrings = false)]
        [StringLength(300, ErrorMessage = "Campo Tipo suporta até 300 caracteres.")]
        public string Type { get; set; }
        [Required(ErrorMessage = "Descrição é obrigatório", AllowEmptyStrings = false)]
        [StringLength(300, ErrorMessage = "Campo Descrição suporta até 300 caracteres.")]
        public string Description { get; set; }
    }
}