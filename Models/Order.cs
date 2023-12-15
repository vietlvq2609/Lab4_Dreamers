namespace Lab4_Dreamers.Models
{
    public class Order
    {
        public int OrderID { get; set; }

        public String? CustomerID { get; set; }
        public int EmployeeID { get; set; }
        public DateTime OrderDate { get; set; }

        public DateTime RequiredDate { get; set; }
    }
}
