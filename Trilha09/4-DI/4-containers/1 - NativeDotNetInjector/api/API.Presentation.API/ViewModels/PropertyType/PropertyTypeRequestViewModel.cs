using System.ComponentModel.DataAnnotations;

namespace API.Presentation.API.ViewModels.ActionType
{
    public class PropertyTypeRequestViewModel 
    {
        [StringLength(100, ErrorMessage = "Campo Tipo suporta até 100 caracteres.")]
        [Required(ErrorMessage = "Campo tipo é obrigatório", AllowEmptyStrings = false)]
        public string Type { get; set; }

        [StringLength(300, ErrorMessage = "Campo Descrição suporta até 300 caracteres.")]
        [Required(ErrorMessage = "Campo descrição é obrigatório", AllowEmptyStrings = false)]
        public string Description { get; set; }
    }
}