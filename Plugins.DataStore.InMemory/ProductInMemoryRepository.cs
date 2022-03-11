using CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.DataStorePluginInterfaces;

namespace Plugins.DataStore.InMemory
{
    public class ProductInMemoryRepository : IProductRepository
    {
        private List<Product> products;
        public ProductInMemoryRepository()
        {
            //自定义一些数据
            products = new List<Product>
            {
                new Product{ProductId=1,CategoryId=1,Name="鸡肉",Quantity=100,Price=1.99},
                new Product{ProductId=2,CategoryId=2,Name="土豆",Quantity=200,Price=4.5},
                new Product{ProductId=3,CategoryId=3,Name="西兰花",Quantity=3000,Price=1.2},
            };
        }

        public void AddProduct(Product product)
        {
            if (products.Any(x => x.Name.Equals(product.Name, StringComparison.OrdinalIgnoreCase))) return;
            if (products != null && products.Count > 0)
            {
                var MaxId = products.Max(p => p.ProductId);
                product.ProductId = MaxId + 1;
            }
            else
            {
                product.ProductId = 1;
            }
            products.Add(product);

        }

        public void UpdateProduct(Product product)
        {
            var productToUpdate = GetProductByID(product.ProductId);
            if (productToUpdate != null)
            {
                productToUpdate.Name = product.Name;
                productToUpdate.CategoryId = product.CategoryId;
                productToUpdate.Quantity = product.Quantity;
                productToUpdate.Price = product.Price;
            }
        }

        public IEnumerable<Product> GetProducts()
        {
            return this.products;
        }

        public Product GetProductByID(int productId)
        {
            return products.FirstOrDefault(x => x.ProductId == productId);
        }

        public void DeleteProduct(int productID)
        {
            products.Remove(GetProductByID(productID));
        }
    }
}
