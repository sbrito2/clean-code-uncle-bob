
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
using NUnit.Framework;
using Shouldly;
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

        [SetUp]
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
            
            mockRepository.Setup(p => p.Find(It.IsAny<Object[]>()))
                .Returns(new Func<Object[], Product>(
                             id => this.products.Find(p => (id).Contains(p.Id))));
            
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

        [TearDown]
        public void DisposeTest()
        {
            this.productService = null;
            this.unitOfWork = null;
            this.productRepository = null;
            if (this.dbEntities != null)
                this.dbEntities.Dispose();
            this.products = null;
        }

        [Test]
        public void ShouldGetAllProducts()
        {
            var genericList = this.productService.GetAll();
            if (products != null)
            {
                var productsList = genericList.Select( productEntity =>
                        new Product {Id = productEntity.Id, Name = productEntity.Name}).ToList();

                var comparer = new ProductComparer();

                CollectionAssert.AreEqual(
                    productsList.OrderBy(product => product, comparer),
                    this.products.OrderBy(product => product, comparer), comparer);
            }
        }

        [Test]
        public void ShouldGetAllProducts_returnEmptyList()
        {
            this.products.Clear();

            var products = this.productService.GetAll();

            products.Count().ShouldBe(0);
            SetUpProducts();
        }

        [Test]
        public void ShouldGetProductById()
        {
            var product = this.productService.Find(2);

            product.ShouldBe(this.products.FirstOrDefault(x => x.Id == 2));
        }

        [Test]
        public void ShouldGetProductById_returnNull()
        {
            Product product = this.productService.Find(0);
            product.ShouldBeNull();
        }

        [Test]
        public void ShouldAddProduct()
        {
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
            (newProduct.Id).ShouldBe(this.productService.GetAll().Last().Id);
        }

        [Test]
        public void ShouldUpdateProduct()
        {
            var firstProduct = this.products.First();
            firstProduct.Name = "Chocolate updated";
            var updatedProduct = new Product()
            {
                Id = firstProduct.Id,
                Name = firstProduct.Name
            };

            this.productService.Update(updatedProduct);

            firstProduct.Id.ShouldBe(1);
            this.products.FirstOrDefault().Name.ShouldBe("Chocolate updated");
        }

        [Test]
        public void ShouldDeleteProduct()
        {
            int maxID = this.products.Max(a => a.Id); 
            var lastProduct = this.products.Last();

            this.EFDbSetTypeTrackerSimulator = lastProduct;
            this.productService.Delete(lastProduct);
            
            maxID.ShouldBeGreaterThan(this.products.Max(a => a.Id));
        }

        [Test]
        public void ShouldNotDeleteProduct()
        {
            var product = new Product()
            {
                Id = 0
            };
            int totalInitial = this.productService.GetAll().Count();

            this.productService.Delete(product);
            
            totalInitial.ShouldBe(this.productService.GetAll().Count());
        }
    }
}