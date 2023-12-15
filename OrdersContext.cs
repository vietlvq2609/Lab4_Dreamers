

using Lab4_Dreamers.Models;
using System.Data.SqlClient;

namespace Lab4_Dreamers
{
    public class OrdersContext
    {
        private string connectionString = "Data Source=.\\HOANGPHUCSEIZA;Initial Catalog=LAB04;Integrated Security=True";
        public OrdersContext()
        {
        }
        public List<Order> GetOrdersFromDatabase()
        {
            List<Order> orders = new();

            using (SqlConnection connection = new(this.connectionString))
            {
                connection.Open();

                string query = "SELECT * FROM Orders";

                using (SqlCommand command = new(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Order order = new()
                            {
                                OrderID = reader.GetInt32(reader.GetOrdinal("OrderID")),
                                CustomerID = reader.GetString(reader.GetOrdinal("CustomerID")),
                                EmployeeID = reader.GetInt32(reader.GetOrdinal("EmployeeID")),
                                OrderDate = reader.GetDateTime(reader.GetOrdinal("OrderDate")),
                                RequiredDate = reader.GetDateTime(reader.GetOrdinal("RequiredDate")),

                            };

                            orders.Add(order);
                        }
                    }
                }
            }

            return orders;
        }
    }
}
