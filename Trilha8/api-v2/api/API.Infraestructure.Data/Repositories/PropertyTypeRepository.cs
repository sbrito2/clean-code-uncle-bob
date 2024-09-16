using API.Domain.Entities;
using API.Domain.Repositories;
using API.Infraestructure.Data.Repositories.Base;
using API.Infraestructure.Data.Context;

namespace API.Infraestructure.Data
{
    public class PropertyTypeRepository : Repository<PropertyType>, IPropertyTypeRepository
    {
        private readonly DomainContext context;
        public PropertyTypeRepository(DomainContext context) : base(context)
        {
            this.context = context;
        }
    }
}