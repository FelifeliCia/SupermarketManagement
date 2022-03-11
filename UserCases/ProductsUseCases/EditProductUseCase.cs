using CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.DataStorePluginInterfaces;

namespace UseCases
{
    public class EditProductUseCase : IEditProductUseCase
    {
        private readonly IProductRepository productsRepository;

        public EditProductUseCase(IProductRepository productsRepository)
        {
            this.productsRepository = productsRepository;
        }

        public void Execute(Product product)
        {
            productsRepository.UpdateProduct(product);
        }
    }
}
