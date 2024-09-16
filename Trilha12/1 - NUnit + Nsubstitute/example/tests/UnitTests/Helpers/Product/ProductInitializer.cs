using System.Collections.Generic;
using api.Models;

namespace TestsHelper
{
    /// <summary>
    /// Data initializer for unit tests
    /// </summary>
    public class ProductInitializer
    {
        public static List<Product> GetAllProducts()
        {
            var products = new List<Product>
                               {
                                   new Product() {Name = "Laptop"},
                                   new Product() {Name = "IPhone"},
                                   new Product() {Name = "PenDrive"},
                                   new Product() {Name = "HD"},
                                   new Product() {Name = "IPad"}
                               };
            return products;
        }
    }
}
