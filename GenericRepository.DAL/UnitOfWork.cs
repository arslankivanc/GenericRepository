using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GenericRepository.DAL.Repositories.Concrete;
using GenericRepository.DAL.Repositories.Interface;

namespace GenericRepository.DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        private GenericRepoContext _context;
        public UnitOfWork(GenericRepoContext context)
        {
            _context = context;
            SupplierRepository = new SupplierRepository(_context);
            ProductRepository = new ProductRepository(_context);
        }
        public ISupplierRepository SupplierRepository { get; private set; }

        public IProductRepository ProductRepository { get; private set; }

        public void Dispose()
        {
            _context.Dispose();
        }

        public int SaveOk()
        {
            return _context.SaveChanges();
        }
    }
}
