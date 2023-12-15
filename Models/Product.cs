using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Lab4_Dreamers.Models
{
    public class Product
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public string QuantityPerUnit { get; set; }
        public Decimal UnitPrice { get; set; }
    }
}
