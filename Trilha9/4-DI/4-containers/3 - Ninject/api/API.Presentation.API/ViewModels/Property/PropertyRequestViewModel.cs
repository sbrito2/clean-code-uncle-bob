using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace API.Presentation.API.ViewModels.Property
{
    public class PropertyRequestViewModel 
    {
        [StringLength(50, ErrorMessage = "Campo título suporta até 50 caracteres.")]
        [Required(ErrorMessage = "Campo título é obrigatório", AllowEmptyStrings = false)]
        public string Title { get; set; }

        [StringLength(300, ErrorMessage = "Campo descrição suporta até 300 caracteres.")]
        [Required(ErrorMessage = "Campo descrição é obrigatório", AllowEmptyStrings = false)]
        public string Description { get; set; }
        public int  Bedrooms { get; set; }
        public int  Bathrooms { get; set; }
        public int ParkingSpaces { get; set; }
        public decimal Area { get; set; }
        [Required(ErrorMessage = "Campo valor base é obrigatório", AllowEmptyStrings = false)]
        public decimal BaseValue { get; set; }
        [Required(ErrorMessage = "Campo valor inicial é obrigatório", AllowEmptyStrings = false)]
        public decimal InitialBid { get; set; }
        public int? ApartmentNumber { get; set; }

        [StringLength(100, ErrorMessage = "Campo endereço suporta até 100 caracteres.")]
        [Required(ErrorMessage = "Campo endereço é obrigatório", AllowEmptyStrings = false)]
        public string Address { get; set; }

        [StringLength(7, ErrorMessage = "Campo numero suporta até 7 caracteres.")]
        [Required(ErrorMessage = "Campo número é obrigatório", AllowEmptyStrings = false)]
        public string Number { get; set; }

        [StringLength(9, ErrorMessage = "Campo Cep suporta até 9 caracteres.")]
        [Required(ErrorMessage = "Campo CEP é obrigatório", AllowEmptyStrings = false)]
        public string Cep { get; set; }
        [Required(ErrorMessage = "Campo cidade é obrigatório", AllowEmptyStrings = false)]
        public int CityId { get; set; }

        [Required(ErrorMessage = "Campo tipo de propriedade é obrigatório", AllowEmptyStrings = false)]
        public int PropertyTypeId { get; set; }

        [StringLength(10, ErrorMessage = "Campo latitude suporta até 10 caracteres.")]
        public string Latitude { get; set; }

        [StringLength(10, ErrorMessage = "Campo longitude suporta até 10 caracteres.")]
        public string Longitude { get; set; }

        [StringLength(300, ErrorMessage = "Campo streetView suporta até 300 caracteres.")]
        public string  StreetViewUrl { get; set; }

        [Required(ErrorMessage = "Campo tipo de lelão é obrigatório", AllowEmptyStrings = false)]
        public int  ActionTypeId { get; set; }
        public bool  IsPopular { get; set; }
        public List<int>  ResourcesIds { get; set; }
        public List<IFormFile> photos { get; set; } 
    }
}