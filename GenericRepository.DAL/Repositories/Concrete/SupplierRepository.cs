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
    public class SupplierRepository : Repository<Supplier>, ISupplierRepository
    {
        public GenericRepoContext genRepoContext { get { return _context as GenericRepoContext; } }
        public SupplierRepository(GenericRepoContext context):base(context)
        {
            
        }
        public IEnumerable<Supplier> GetSuppliersWithProducts()
        {
            return genRepoContext.Suppliers.Include("Products").ToList();
        }

        public IEnumerable<Supplier> GetTopSuppliers(int count)
        {
            return genRepoContext.Suppliers.Take(count);
        }

        public void Update(Supplier supplier)
        {
            genRepoContext.Entry(supplier).State = EntityState.Modified;
        }
    }
}
