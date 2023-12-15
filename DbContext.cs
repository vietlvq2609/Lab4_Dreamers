

using Lab4_Dreamers.Models;
using System.Data.SqlClient;

namespace Lab4_Dreamers
{
    public class DbContext
    {
        
        private string connectionString = "server=DESKTOP-J648SAE; database=NorthWind; Trusted_connection=True; Encrypt=False";
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
                                Address = reader.GetString(reader.GetOrdinal("Address")),
                                City = reader.GetString(reader.GetOrdinal("City")),
                                Country = reader.GetString(reader.GetOrdinal("Country")),
                            };

                            suppliers.Add(supplier);
                        }
                    }
                }
            }
            return suppliers;
        }

        public List<Supplier> GetSuppliers(int choice=0)
        {
            List<Supplier> suppliers = new();

            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM Suppliers";

                if(choice == 1)
                {
                    query = "SELECT * FROM Suppliers " +
                               "WHERE SupplierID IN " +
                               "(SELECT SupplierID FROM Products GROUP BY SupplierID HAVING COUNT(ProductID) >= 10)";
                }else if(choice ==2)
                {
                    query = "SELECT * FROM Suppliers " +
                               "WHERE SupplierID IN " +
                               "(SELECT SupplierID FROM Products GROUP BY SupplierID HAVING COUNT(ProductID) = 0)";
                }
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Supplier supplier = new Supplier
                            {
                                SupplierID = (int)reader["SupplierID"],
                                CompanyName = reader["CompanyName"].ToString(),
                                ContactName = reader["ContactName"].ToString(),
                                Address = reader["Address"].ToString(),
                                City = reader["City"].ToString(),
                                Country = reader["Country"].ToString()
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
