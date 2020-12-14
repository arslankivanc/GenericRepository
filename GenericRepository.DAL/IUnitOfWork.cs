using GenericRepository.DAL.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericRepository.DAL
{
    public interface IUnitOfWork:IDisposable
    {
        ISupplierRepository SupplierRepository { get; }
        IProductRepository ProductRepository { get; }
        int SaveOk();
    }
}
