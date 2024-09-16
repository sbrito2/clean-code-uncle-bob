using System.Collections.Generic;
using API.Domain.Entities.Base;

namespace API.Domain.Entities
{
    public class Property : Entity
    {
        public string Description { get; set; }
        public decimal Area { get; set; }
        public string PhotosPath { get; set; }
        public decimal BaseValue { get; set; }
        public string Address { get; set; }
        public string Number { get; set; }
        public string Cep { get; set; }
        public int CityId { get; set; }
        public int PropertyTypeId { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public string  StreetViewUrl { get; set; }
        public int UserId { get; set; }
        public City City { get; set; }
        public User User { get; set; }
        public PropertyType PropertyType { get; set; }
        public ICollection<Resource> Resources { get; set; }
        public ICollection<Action> Actions { get; set; }
        
    }
}