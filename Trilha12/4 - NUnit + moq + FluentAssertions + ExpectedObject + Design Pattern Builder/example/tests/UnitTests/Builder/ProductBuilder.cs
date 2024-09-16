using System.Collections.Generic;
using api.Models;

public class ProductBuilder
{
    private Product product;
    private List<Product> products;

    public ProductBuilder()
    {
        product = new Product();
        products = new List<Product> ();
    }

    public ProductBuilder Default()
    {
        product.Name = "Book";

        products = new List<Product>
                               {
                                   new Product() {Name = "Laptop", Id = 0},
                                   new Product() {Name = "IPhone", Id = 1},
                                   new Product() {Name = "PenDrive", Id = 2},
                                   new Product() {Name = "HD", Id = 3},
                                   new Product() {Name = "IPad", Id = 4}
                               };

        return this;
    }

    public ProductBuilder WithName(string name)
    {
        product.Name = name;
        return this;
    }

    public ProductBuilder WithId(int id)
    {
        product.Id = id;
        return this;
    }

    public Product Build()
    {
        return product;
    }

    public List<Product> BuildList()
    {
        return products;
    }
}