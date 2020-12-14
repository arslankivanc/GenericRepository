using GenericRepository.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericRepository.DAL.Repositories.Interface
{
    public interface ISupplierRepository:IRepository<Supplier>
    {
        IEnumerable<Supplier> GetTopSuppliers(int count);
        IEnumerable<Supplier> GetSuppliersWithProducts();
        void Update(Supplier supplier);
    }
}
