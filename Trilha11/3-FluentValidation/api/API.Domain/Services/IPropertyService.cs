

using System.Collections.Generic;
using System.Threading.Tasks;
using API.Domain.CoreLogic.Entities;
using API.Domain.Queries;
using API.Domain.Queries.Property;
using Microsoft.AspNetCore.Http;

namespace API.Domain.Services
{
    public interface IPropertyService : IService<Property>
    {
        PaginatedQueryResult<Property> Index(int page, PropertyQuery filter);
        void Add(Property property, List<IFormFile> photos);
        List<Property> GetAll();
        void Update(Property property, List<IFormFile> photos);
        byte[] GetImage(int id, string fileName);
        List<Property> GetRandomProperties();
    }
}
