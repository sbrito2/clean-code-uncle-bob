
using System;
using System.Collections.Generic;
using System.Linq;
using api.Models;
using API.Base;
using API.Domain.UnitOfWork;
using API.Repositories;
using API.Repositories.Base;
using API.Services;
using NSubstitute;
using NUnit.Framework;
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
            this.dbEntities = Substitute.For<contextEntities>(); 
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
            var mockRepository = Substitute.For<IProductRepository>();

            mockRepository.GetAll().Returns(this.products);
            mockRepository.Received(2).GetAll();

            mockRepository.Get(Arg.Any<int>()).Returns(args => this.products.Find(p => p.Id.Equals((int)args[0])));
            
            mockRepository.Any(Arg.Any<int>()).Returns(args => this.products.Any(p => p.Id == (int)args[0]));

            return mockRepository; 
        }

        private IUnitOfWork SetUpUnitOfWork()
        {
            var mockUnitOfWork = Substitute.For<IUnitOfWork>();

            mockUnitOfWork.Add((Arg.Any<Product>())).Returns(args =>
                                                  {
                                                    dynamic maxProductID = this.products.Last().Id;
                                                    dynamic nextProductID = maxProductID + 1;
                                                    var newProduct = ((Product)args[0]);
                                                    var product = new Product()
                                                    {
                                                        Id = nextProductID,
                                                        Name = newProduct.Name
                                                    };
                                                    this.products.Add(product);

                                                    return new Entity()
                                                    {
                                                        Id = nextProductID,
                                                    };
                                                  });
        

            mockUnitOfWork.Update(Arg.Any<Product>()).Returns(args =>
                                                  {
                                                    var prod = (Product)args[0];
                                                    var oldProduct = this.products.Find(a => a.Id == prod.Id);
                                                    oldProduct = prod;

                                                    return (Entity) prod;
                                                  });

            mockUnitOfWork.Delete(Arg.Any<Product>()).Returns(args =>
                                                  {
                                                    var prod = (Product)args[0];
                                                    var productToRemove = this.products.Find(a => a.Id == prod.Id);

                                                    if (productToRemove != null)
                                                    {
                                                        this.products.Remove(productToRemove);
                                                        return true;
                                                    }

                                                    return false;
                                                  });

            // Return mock implementation object
            return mockUnitOfWork; 
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

            Assert.True(products.Count() == 0);
            SetUpProducts();
        }

        [Test]
        public void ShouldGetProductById()
        {
            var product = this.productService.Find(2);
            
            var helper = new ProductComparer();

            Assert.True(helper.Compare(product, this.products.Where(x => x.Id == 2)) > 0);
        }

        [Test]
        public void ShouldGetProductById_returnNull()
        {
            var product = this.productService.Find(0);
            Assert.Null(product);
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
            Assert.That(lastProduct + 1, Is.EqualTo(this.productService.GetAll().Last().Id));
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

            Assert.That(firstProduct.Id, Is.EqualTo(1)); 
            Assert.That(this.products.First().Name, Is.EqualTo("Chocolate updated")); 
        }

        [Test]
        public void ShouldDeleteProduct()
        {
            int maxID = this.products.Max(a => a.Id); 
            var lastProduct = this.products.Last();

            this.EFDbSetTypeTrackerSimulator = lastProduct;

            this.productService.Delete(lastProduct);
            Assert.That(maxID, Is.GreaterThan(this.products.Max(a => a.Id))); 
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
            Assert.True(totalInitial == this.productService.GetAll().Count()); 
        }
    }
}