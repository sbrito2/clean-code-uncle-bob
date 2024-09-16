using System.Collections.Generic;

namespace API.Domain.Queries.Property
{
    public class PropertyQuery
    {
        public int  Bedrooms { get; set; }
        public int  Bathrooms { get; set; }
        public int ParkingSpaces { get; set; }
        public decimal Area { get; set; }
        public int StateId { get; set; }
        public int CityId { get; set; }
        public List<int> ResourceTypeIds { get; set; }
        public decimal MaxBid { get; set; }
        public decimal MinBid { get; set; }
    }
}
