using API.Domain.Entities;
using API.Domain.Repositories;
using API.Infra.Data.Repositories.Base;
using API.Infra.Data.Context;
using System.Collections.Generic;
using API.Domain;
using System.Linq;

namespace API.Infra.Data
{
    public class CityRepository : Repository<City>, ICityRepository
    {
        private readonly DomainContext context;
        public CityRepository(DomainContext context) : base(context)
        {
            this.context = context;
        }

        public List<City> GetAll(string filter)
        {
            var cities  = this.Query();

            var FilteredCities = ApplyFilter(cities, filter);

            return FilteredCities.ToList();
        }

        private IQueryable<City> ApplyFilter(IQueryable<City> cities, string filter)
        {
            if(filter == null)
            {
                return cities;
            }

            return cities.Where(x => x.Name.Trim().ToLower().Contains(filter.Trim().ToLower()));
        }
    }
}