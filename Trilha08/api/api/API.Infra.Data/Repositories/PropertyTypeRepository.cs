using API.Domain.Entities;
using API.Domain.Repositories;
using API.Infra.Data.Repositories.Base;
using API.Infra.Data.Context;

namespace API.Infra.Data
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