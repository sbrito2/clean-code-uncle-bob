using System.Collections.Generic;
using System.Linq;
using API.Domain.Entities;
using API.Domain.Queries;
using API.Domain.Queries.Property;
using API.Domain.Repositories.Base;

namespace API.Domain.Repositories
{
    public interface IPropertyRepository : IRepository<Property>
    {
        Property Get(int id);
        List<Property> GetRamdomProperties(int quantity);
        bool UpdatePhotoPath(int id, string path);
        PaginatedQueryResult<Property> GetAll(GenericPaginatedQuery<PropertyQuery> query);
    }
}