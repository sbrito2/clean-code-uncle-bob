using api.Models;
using API.Repositories;
using API.Repositories.Base;

namespace API.Infraestructure.Data
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private readonly contextEntities context;
        public ProductRepository(contextEntities context) : base(context)
        {
            this.context = context;
        }
    }
}