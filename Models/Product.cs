using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Lab4_Dreamers.Models
{
    public class Product
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public int SupplierId { get; set; }
        public Decimal UnitPrice { get; set; }
        public int UnitsInStock { get; set; }

    }
}
