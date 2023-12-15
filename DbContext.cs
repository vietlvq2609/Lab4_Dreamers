

using Lab4_Dreamers.Models;
using System.Data.SqlClient;

namespace Lab4_Dreamers
{
    public class DbContext
    {
        private string connectionString = "Server=(localdb)\\mssqllocaldb;Database=NorthWind;Trusted_Connection=True;";
        public DbContext()
        {
        }
        public List<Supplier> GetSuppliersFromDatabase()
        {
            List<Supplier> suppliers = new();

            using (SqlConnection connection = new(this.connectionString))
            {
                connection.Open();

                string query = "SELECT * FROM Suppliers";

                using (SqlCommand command = new(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Supplier supplier = new()
                            {
                                SupplierID = reader.GetInt32(reader.GetOrdinal("SupplierID")),
                                CompanyName = reader.GetString(reader.GetOrdinal("CompanyName")),
                                ContactName = reader.GetString(reader.GetOrdinal("ContactName")),
                            };

                            suppliers.Add(supplier);
                        }
                    }
                }
            }

            return suppliers;
        }
        public List<Product> GetProducts(string comName="",string proName="")
        {
            List<Product> products = new();

            using (SqlConnection connection = new(this.connectionString))
            {
                connection.Open();

                string query = "SELECT * FROM Products";

                if (comName.Length > 0)
                {
                    query = "select * from Products " +
                        "where SupplierID in (SELECT SupplierID from Suppliers where CompanyName='"+comName+"')";
                } else if (proName.Length > 0)
                {
                    query = "select * from Products " +
                       "where ProductName like '"+proName+"%'";
                }

                using (SqlCommand command = new(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Product product = new()
                            {
                                ProductID = (Int32)reader.GetSqlInt32(reader.GetOrdinal("ProductID")),
                                ProductName = reader.GetString(reader.GetOrdinal("ProductName")),
                                QuantityPerUnit = reader.GetString(reader.GetOrdinal("QuantityPerUnit")),
                                UnitPrice =(decimal) reader.GetSqlMoney(reader.GetOrdinal("UnitPrice")),
                            };

                            products.Add(product);
                        }
                    }
                }
            }

            return products;
        }
    }
}
