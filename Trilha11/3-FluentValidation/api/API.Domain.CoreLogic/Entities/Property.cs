using System.Collections.Generic;
using API.Domain.CoreLogic.Entities.Base;
using API.Domain.CoreLogic.Specifications;

namespace API.Domain.CoreLogic.Entities
{
    public class Property : Entity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int?  Bedrooms { get; set; }
        public int?  Bathrooms { get; set; }
        public int? ParkingSpaces { get; set; }
        public decimal Area { get; set; }
        public string PhotosPath { get; set; }
        public decimal BaseValue { get; set; }
        public decimal? InitialBid1 { get; set; }
        public decimal? InitialBid2 { get; set; }
        public int? ApartmentNumber { get; set; }
        public string Address { get; set; }
        public string Number { get; set; }
        public string Cep { get; set; }
        public int CityId { get; set; }
        public int PropertyTypeId { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string  StreetViewUrl { get; set; }
        public int? ActionTypeId { get; set; }
        public bool IsPopular { get; set; }
        public City City { get; set; }
        public User User { get; set; }
        public ActionType ActionType { get; set; }
        public PropertyType PropertyType { get; set; }
        public ICollection<Resource> Resources { get; set; }
        public ICollection<Action> Actions { get; set; }
        public ICollection<Customer> Customers { get; set; }

        public override bool IsValid()
        {
            return IsValid(this, new PropertySpecification());
        }
    }
}