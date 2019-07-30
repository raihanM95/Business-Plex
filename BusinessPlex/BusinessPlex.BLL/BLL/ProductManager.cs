using BusinessPlex.Models.Models;
using BusinessPlex.Repository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessPlex.BLL.BLL
{
    public class ProductManager
    {
        ProductRepository _productRepository = new ProductRepository();

        public bool AddProduct(Product product)
        {
            return _productRepository.AddProduct(product);
        }

        public bool DeleteProduct(Product product)
        {
            return _productRepository.DeleteProduct(product);
        }

        public bool UpdateProduct(Product product)
        {
            return _productRepository.UpdateProduct(product);
        }

        public List<Product> GetAll()
        {
            return _productRepository.GetAll();
        }

        public Product GetByID(Product product)
        {
            return _productRepository.GetByID(product);
        }
    }
}
