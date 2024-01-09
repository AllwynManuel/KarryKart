using Entities.Models.ParentCatgoriesClass;
using Entities.Models.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.IServices
{
    public interface IProduct
    {
        Task<IEnumerable<Product>> GetProduct();
        Task<Product> GetProductId(int productId);
        Task<Product> AddProduct(Product product);
        Task<Product> UpdateProduct(Product product);
        Task DeleteProduct(int productId);
    }
}
