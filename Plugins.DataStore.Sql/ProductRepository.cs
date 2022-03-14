using CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.DataStorePluginInterfaces;

namespace Plugins.DataStore.Sql
{
    public class ProductRepository : IProductRepository
    {
        private readonly MarketContext db;

        public ProductRepository(MarketContext db)
        {
            this.db = db;
        }

        public void AddProduct(Product product)
        {
            db.Products.Add(product);

        }

        public void UpdateProduct(Product product)
        {
            var productToUpdate = db.Products.FirstOrDefault(p => p.ProductId == product.ProductId);
            if (productToUpdate == null) return;
            productToUpdate.Name = product.Name;
            productToUpdate.CategoryId = product.CategoryId;
            productToUpdate.Quantity = product.Quantity;
            productToUpdate.Price = product.Price;
            db.SaveChanges();

        }

        public IEnumerable<Product> GetProducts()
        {
            return db.Products.ToList();
        }

        public Product GetProductByID(int productId)
        {
            return db.Products.FirstOrDefault(p => p.ProductId == productId);
        }

        public void DeleteProduct(int productID)
        {
            var product = db.Products.FirstOrDefault(p => p.ProductId == productID);
            if (product == null) return;
            db.Products.Remove(product);
            db.SaveChanges();
        }

        public IEnumerable<Product> GetProductsByCategoryId(int categoryId)
        {
            return db.Products.Where(p => p.CategoryId == categoryId).ToList();
        }
    }
}
