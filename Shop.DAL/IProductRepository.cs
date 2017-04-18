﻿namespace Shop.DAL
{
    using System;
    using Models;
    using System.Collections.Generic;

    public interface IProductRepository : IDisposable
    {
        // Add reference to the query methods here

        IList<Product> GetProducts();

        void CreateProduct(Product product, string username);

        IList<Category> GetCategories();

        Product Details(int id);
    }
}
