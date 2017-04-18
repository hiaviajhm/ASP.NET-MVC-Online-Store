﻿namespace Shop.DAL
{
    using System;
    using Models;
    using Data;
    using System.Collections.Generic;
    using System.Linq;

    public class ProductRepository : IProductRepository, IDisposable
    {
        private ShopContext _context;

        public ProductRepository()
        {
            _context = new ShopContext();
        }

        // Add query methods with their logic here

        public IList<Product> GetProducts()
        {
            return _context.Products.ToList();
        }

        public void CreateProduct(Product product, string username)
        {
            var productList = new List<Category>();
            foreach (Category cat in product.Categories.Where(c => c.Checked))
            {
                productList.Add(_context.Categories.FirstOrDefault(c => c.Id == cat.Id));
            }
            product.Categories = productList;

            product.Owner = _context.Users.FirstOrDefault(u => u.UserName == username);

            _context.Products.Add(product);
            Save();
        }

        public IList<Category> GetCategories()
        {
            return _context.Categories.ToList();
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        #region dispose
        private bool disposed = false;

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            disposed = true;
        }
        #endregion
    }
}
