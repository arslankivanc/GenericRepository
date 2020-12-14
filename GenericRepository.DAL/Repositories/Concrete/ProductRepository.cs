using GenericRepository.DAL.Repositories.Interface;
using GenericRepository.Domains;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericRepository.DAL.Repositories.Concrete
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(GenericRepoContext context):base(context)
        {

        }
        public IEnumerable<Product> GetProductsWithSuppliers()
        {
            return genRepocontext.Products.Include(x=>x.Supplier).ToList();
        }

        public void Update(Product product)
        {
            genRepocontext.Entry(product).State = EntityState.Modified;
        }

        public GenericRepoContext genRepocontext { get { return _context as GenericRepoContext; } }
    }
}
