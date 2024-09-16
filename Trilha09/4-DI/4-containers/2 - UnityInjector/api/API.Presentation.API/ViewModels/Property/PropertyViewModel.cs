using System.Collections.Generic;

namespace API.Presentation.API.ViewModels.Property
{
    public class PropertyViewModel 
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int  bedrooms { get; set; }
        public int  Bathrooms { get; set; }
        public int ParkingSpaces { get; set; }
        public decimal Area { get; set; }
        public decimal BaseValue { get; set; }
        public decimal InitialBid { get; set; }
        public int? ApartmentNumber { get; set; }
        public string Address { get; set; }
        public string Number { get; set; }
        public string Cep { get; set; }
        public int CityId { get; set; }
        public GenericComboboxViewModel PropertyType { get; set; }
        public List<GenericComboboxViewModel> ResourcesTypes { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string  StreetViewUrl { get; set; }
        public GenericComboboxViewModel  ActionType { get; set; }
        public string  PhotoUrl { get; set; }
    }
}