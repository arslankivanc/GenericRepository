using GenericRepository.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericRepository.DAL.Repositories.Interface
{
    public interface IProductRepository:IRepository<Product>
    {
        IEnumerable<Product> GetProductsWithSuppliers();
        void Update(Product product);
    }
}
