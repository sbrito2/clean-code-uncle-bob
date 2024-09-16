using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using API.Domain.Entities;
using API.Domain.Queries;
using API.Domain.Queries.Property;
using API.Domain.Repositories;
using API.Infra.Data.Context;
using API.Infra.Data.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace API.Infra.Data
{
    public class PropertyRepository : Repository<Property>, IPropertyRepository
    {
        private readonly DomainContext context;
        public PropertyRepository(DomainContext context) : base(context)
        {
            this.context = context;
        }

        public Property Get(int id)
        {
            var property = this.context.Properties
                .Include(x => x.Resources)
                    .ThenInclude(x => x.ResourceType)
                .Include(x => x.City)
                    .ThenInclude(x => x.State)
                .Include(x => x.PropertyType)
                .Include(x => x.ActionType)
                .FirstOrDefault(x => x.Id == id);

            return property;
        }

        public bool UpdatePhotoPath(int id, string path)
        {
            var property = Get(id);

            property.PhotosPath =  $"{path}{Path.DirectorySeparatorChar}{id.ToString()}";

            return true;
        }

        public PaginatedQueryResult<Property> GetAll(GenericPaginatedQuery<PropertyQuery> query)
        {
            var properties  = this.Query()
                .Include(x => x.Resources)
                    .ThenInclude(x => x.ResourceType)
                .Include(x => x.City)
                    .ThenInclude(x => x.State)
                .Include(x => x.PropertyType)
                .Include(x => x.ActionType);

            var FilteredProperties = ApplyFilter(properties, query.Filter);

            return ApplyPagination(FilteredProperties.ToList().OrderBy(x => x.CityId).AsQueryable(), query);
        }

        private IQueryable<Property> ApplyFilter(IQueryable<Property> properties, PropertyQuery filter)
        {
            if (filter.Bathrooms != 0)
            {
                properties = properties.Where(w => w.Bathrooms == filter.Bathrooms);
            }

            if (filter.Bedrooms != 0)
            {
                properties = properties.Where(w => w.Bedrooms == filter.Bedrooms);
            }

            if (filter.ParkingSpaces != 0)
            {
                properties = properties.Where(w => w.ParkingSpaces == filter.ParkingSpaces);
            }

            if (filter.Area != 0)
            {
                properties = properties.Where(w => w.Area == filter.Area);
            }

            if (filter.StateId != 0)
            {
                properties = properties.Where(w => w.City.StateId == filter.StateId);
            }

            if (filter.CityId != 0)
            {
                properties = properties.Where(w => w.CityId == filter.CityId);
            }
            
            if (filter.ResourceTypeIds != null && filter.ResourceTypeIds.Count() > 0)
            {
                properties = properties.Where(w => w.Resources.Any(y => filter.ResourceTypeIds.Contains(y.ResourceTypeId)));
            }

            if (filter.MaxBid != 0)
            {
                properties = properties.Where(w => w.InitialBid < filter.MaxBid);
            }

            if (filter.MinBid!= 0)
            {
                properties = properties.Where(w => w.InitialBid > filter.MinBid);
            }

            return properties;
        }

        public List<Property> GetRamdomProperties(int quantity)
        {
            var entities = context.Properties
                .Include(x => x.Resources)
                    .ThenInclude(x => x.ResourceType)
                .Include(x => x.City)
                    .ThenInclude(x => x.State)
                .Include(x => x.PropertyType)
                .Include(x => x.ActionType).Where(x => x.IsPopular).ToList();

            var properties = new List<Property>();

            var total = entities.Count();
            if(total < quantity) quantity = total;
            
            while(quantity > 0)
            {
                properties.Add(this.GetRamdom(entities, properties.Select(x => x?.Id ?? 0).ToList()));
                quantity--;
            }

            return properties.ToList();
        }

        private Property GetRamdom(List<Property> entities, List<int> avoidIds)
        {
            Random rand = new Random();
            int toSkip = rand.Next(1, context.Properties.Count());

            var property = entities.Where(x => !avoidIds.Contains(x.Id))
                .OrderBy(x => Guid.NewGuid()).Skip(toSkip).Take(1).FirstOrDefault();
            
            return property;
        }
    }
}