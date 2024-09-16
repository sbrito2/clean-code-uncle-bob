using System.Linq;
using API.Domain.Entities;
using API.Domain.Repositories;
using API.Infra.Data.Repositories.Base;
using API.Infra.Data.Context;
using System.Collections.Generic;

namespace API.Infra.Data
{
    public class ResourceRepository : Repository<Resource>, IResourceRepository
    {
        private readonly DomainContext context;
        public ResourceRepository(DomainContext context) : base(context)
        {
            this.context = context;
        }

        public List<Resource> GetAllByProperty(int propertyId)
        {
            var resources  = this.Query().Where(x => x.PropertyId == propertyId).ToList();

            return resources;
        }
    }
}