using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using PDG.Domain.Entities.Base;

namespace PDG.Domain.Entities
{
    [Table("Property")]
    public class Property : Entity
    {
        public string Description { get; set; }
        public string Area { get; set; }
        public string PhotosPath { get; set; }
        public decimal BaseValue { get; set; }
        public string Address { get; set; }
        public string Number { get; set; }
        public string Cep { get; set; }
        public int CityId { get; set; }
        public int PropertyTypeId { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string  StreetViewUrl { get; set; }
        public int UserId { get; set; }
        public City City { get; set; }
        public User User { get; set; }
        public PropertyType PropertyType { get; set; }
        public ICollection<Resource> Resources { get; set; }
        public ICollection<Action> Actions { get; set; }
        
    }
}