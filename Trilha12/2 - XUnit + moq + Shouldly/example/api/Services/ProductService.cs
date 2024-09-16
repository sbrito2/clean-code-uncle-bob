

using api.Models;
using API.Domain.UnitOfWork;
using API.Repositories;
using API.Services.Base;

namespace API.Services
{
    public class ProductService : Service<Product>, IProductService
    {
        private readonly IProductRepository productRepository;

        public ProductService(IProductRepository productRepository, IUnitOfWork unitOfWork)
        : base(productRepository, unitOfWork)
        {
            this.productRepository = productRepository;
        }
    }
}
