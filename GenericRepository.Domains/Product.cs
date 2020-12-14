using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericRepository.Domains
{
    public class Product
    {
        public int ID { get; set; }
        public string UrunAdi { get; set; }
        public bool Sonlandi { get; set; }
        public int SupplierID { get; set; }
        public Supplier Supplier { get; set; }
    }
}
