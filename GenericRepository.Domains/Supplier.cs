using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericRepository.Domains
{
    public class Supplier
    {
        public Supplier()
        {
            Products = new List<Product>();
        }
        public int ID { get; set; }
        public string SirketAdi { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
