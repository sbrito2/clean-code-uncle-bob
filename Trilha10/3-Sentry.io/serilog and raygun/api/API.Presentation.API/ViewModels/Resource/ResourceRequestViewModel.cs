using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace API.Presentation.API.ViewModels.Resource
{
    public class ResourceRequestViewModel 
    {
        [Required(ErrorMessage = "Campo descrição é obrigatório", AllowEmptyStrings = false)]
        [StringLength(300, ErrorMessage = "Campo descrição suporta até 300 caracteres.")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Campo valor é obrigatório", AllowEmptyStrings = false)]
        public decimal Value { get; set; }

        [Required(ErrorMessage = "Campo tipo de recurso é obrigatório", AllowEmptyStrings = false)]
        public int ResourceTypeId { get; set; }

        [Required(ErrorMessage = "Campo imóvel é obrigatório", AllowEmptyStrings = false)]
        public int PropertyId { get; set; }
    }
}