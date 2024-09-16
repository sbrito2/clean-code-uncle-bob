

using System.Collections.Generic;
using System.Threading.Tasks;
using API.Domain.Entities;
using API.Domain.Queries;
using API.Domain.Queries.Property;
using Microsoft.AspNetCore.Http;

namespace API.Domain.Services
{
    public interface IPropertyService
    {
        PaginatedQueryResult<Property> Index(int page, PropertyQuery filter);
        bool Add(Property property, List<IFormFile> photos);
        List<Property> GetAll();
        Property Find(int id);
        bool Any(int id);
        bool Update(Property property, List<IFormFile> photos);
        void Delete(int id);
        byte[] GetImage(int id, string fileName);
        List<Property> GetRandomProperties();
    }
}
