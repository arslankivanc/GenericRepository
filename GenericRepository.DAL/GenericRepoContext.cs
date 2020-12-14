using GenericRepository.Domains;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericRepository.DAL
{
    public class GenericRepoContext:DbContext
    {
        public GenericRepoContext():base("GenRepoContext")
        {

        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
    }
}
