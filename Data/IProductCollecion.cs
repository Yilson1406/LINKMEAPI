using LINKME.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LINKME.Data
{
    public interface IProductCollecion
    {
        Task InsertPorduct(Product product);
        Task UpdateProduct(Product product);
        Task DeleteProduct(string id);

        Task<List<Product>> GetAllProduct();
        Task<Product> GetProductById(string id);

    }
}
