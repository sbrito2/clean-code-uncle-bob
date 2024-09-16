
using System;
using System.Collections.Generic;
using System.Linq;
using api.Models;
using API.Base;
using API.Domain.UnitOfWork;
using API.Repositories;
using API.Repositories.Base;
using API.Services;
using Moq;
using Xunit;
using TestsHelper;

namespace ProductServiceTests
{
    public class UnitTest1
    {
        private IProductService productService;
        private IUnitOfWork unitOfWork;
        private List<Product> products;
        private IProductRepository productRepository;
        private contextEntities dbEntities;
        private Product EFDbSetTypeTrackerSimulator;

        public void InitializeTest()
        {
            this.products = SetUpProducts();
            this.dbEntities = new Mock<contextEntities>().Object;
            this.productRepository = SetUpProductRepository();
            this.unitOfWork = SetUpUnitOfWork();

            this.productService = new ProductService(this.productRepository, this.unitOfWork);
        }       

        private static List<Product> SetUpProducts()
        {
            var prodId = new int();
            var products = ProductInitializer.GetAllProducts();
            foreach (Product prod in products)
                prod.Id = ++prodId;
            return products;
        }

        private IProductRepository SetUpProductRepository()
        {
            var mockRepository = new Mock<IProductRepository>();

            mockRepository.Setup(p => p.GetAll()).Returns(this.products);

            mockRepository.Setup(p => p.Get(It.IsAny<int>()))
                .Returns(new Func<int, Product>(
                             id => this.products.Find(p => p.Id.Equals(id))));
            
            mockRepository.Setup(p => p.Any(It.IsAny<int>()))
                .Returns(new Func<int, bool>(
                             id => this.products.Any(p => p.Id == id)));

            return mockRepository.Object;
        }

        private IUnitOfWork SetUpUnitOfWork()
        {
            var mockUnitOfWork = new Mock<IUnitOfWork>();

            mockUnitOfWork.Setup(p => p.Add((It.IsAny<Product>()))).Callback(new Action<Entity>(newProduct =>
                                                  {
                                                    dynamic maxProductID = this.products.Last().Id;
                                                    dynamic nextProductID = maxProductID + 1;
                                                    newProduct.Id = nextProductID;
                                                    var product = new Product()
                                                    {
                                                        Id = this.EFDbSetTypeTrackerSimulator.Id,
                                                        Name = this.EFDbSetTypeTrackerSimulator.Name
                                                    };
                                                    this.products.Add(product);
                                                  }));

            mockUnitOfWork.Setup(p => p.Update(It.IsAny<Product>())).Callback(new Action<Entity>(prod =>
                                                  {
                                                    var oldProduct = this.products.Find(a => a.Id == prod.Id);
                                                    oldProduct = this.EFDbSetTypeTrackerSimulator;
                                                  }));

            mockUnitOfWork.Setup(p => p.Delete(It.IsAny<Product>())).Callback(new Action<Entity>(prod =>
                                                  {
                                                    var productToRemove = this.products.Find(a => a.Id == prod.Id);

                                                    if (productToRemove != null)
                                                          this.products.Remove(productToRemove);
                                                  }));

            // Return mock implementation object
            return mockUnitOfWork.Object;
        }

        public void DisposeTest()
        {
            this.productService = null;
            this.unitOfWork = null;
            this.productRepository = null;
            if (this.dbEntities != null)
                this.dbEntities.Dispose();
            this.products = null;
        }

        [Fact]
        public void ShouldGetAllProducts()
        {
            this.InitializeTest();

            var genericList = this.productService.GetAll();
            if (products != null)
            {
                var productsList = genericList.Select( productEntity =>
                        new Product {Id = productEntity.Id, Name = productEntity.Name}).ToList();

                var comparer = new ProductComparer();

                Assert.True(comparer.CompareList(productsList, this.products) == 0);
            }
        }

        [Fact]
        public void ShouldGetAllProducts_returnEmptyList()
        {
            this.InitializeTest();

            this.products.Clear();

            var products = this.productService.GetAll();

            Assert.True(products.Count() == 0);
            SetUpProducts();
            DisposeTest();
        }

        [Fact]
        public void ShouldGetProductById()
        {
            this.InitializeTest();

            var product = this.productService.Find(2);
            
            var helper = new ProductComparer();
            Assert.True(helper.Compare(product, this.products.Where(x => x.Id == 2)) > 0);
            DisposeTest();
        }

        [Fact]
        public void ShouldGetProductById_returnNull()
        {
            this.InitializeTest();

            var product = this.productService.Find(0);
            Assert.Null(product);
            DisposeTest();
        }

        [Fact]
        public void ShouldAddProduct()
        {
            this.InitializeTest();

            var newProduct = new Product()
            {
                Name = "chocolate"
            };

            var lastProduct = this.products.Max(a => a.Id);
            newProduct.Id = lastProduct + 1;

            this.EFDbSetTypeTrackerSimulator = newProduct;
            this.productService.Add(newProduct);

            var helper = new ProductComparer();
            Assert.True(helper.Compare(newProduct, this.products.Last()) == 0);
            Assert.Equal(lastProduct + 1, this.productService.GetAll().Last().Id);
            DisposeTest();
        }

        [Fact]
        public void ShouldUpdateProduct()
        {
            this.InitializeTest();

            var firstProduct = this.products.First();
            firstProduct.Name = "Chocolate updated";
            var updatedProduct = new Product()
            {
                Id = firstProduct.Id,
                Name = firstProduct.Name
            };

            this.productService.Update(updatedProduct);

            Assert.Equal(firstProduct.Id, 1); 
            Assert.Equal(this.products.First().Name, "Chocolate updated"); 
            DisposeTest();
        }

        [Fact]
        public void ShouldDeleteProduct()
        {
            this.InitializeTest();

            int maxID = this.products.Max(a => a.Id); 
            var lastProduct = this.products.Last();

            this.EFDbSetTypeTrackerSimulator = lastProduct;

            this.productService.Delete(lastProduct);
            Assert.True(maxID > this.products.Max(a => a.Id)); 
            DisposeTest();
        }

        [Fact]
        public void ShouldNotDeleteProduct()
        {
            this.InitializeTest();

            var product = new Product()
            {
                Id = 0
            };
            int totalInitial = this.productService.GetAll().Count();

            this.productService.Delete(product);
            Assert.True(totalInitial == this.productService.GetAll().Count()); 
            DisposeTest();
        }
    }
}