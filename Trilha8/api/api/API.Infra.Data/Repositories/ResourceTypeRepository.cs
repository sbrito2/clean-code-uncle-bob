using API.Domain.Entities;
using API.Domain.Repositories;
using API.Infra.Data.Repositories.Base;
using API.Infra.Data.Context;

namespace API.Infra.Data
{
    public class ResourceTypeRepository : Repository<ResourceType>, IResourceTypeRepository
    {
        private readonly DomainContext context;
        public ResourceTypeRepository(DomainContext context) : base(context)
        {
            this.context = context;
        }
    }
}