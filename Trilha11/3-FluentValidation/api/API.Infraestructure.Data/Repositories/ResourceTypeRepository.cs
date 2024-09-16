using API.Domain.CoreLogic.Entities;
using API.Domain.Repositories;
using API.Infraestructure.Data.Repositories.Base;
using API.Infraestructure.Data.Context;

namespace API.Infraestructure.Data
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