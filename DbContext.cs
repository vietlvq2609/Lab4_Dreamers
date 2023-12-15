﻿

using Lab4_Dreamers.Models;
using System.Data.SqlClient;

namespace Lab4_Dreamers
{
    public class DbContext
    {
        private string connectionString = "Data Source=.\\HOANGPHUCSEIZA;Initial Catalog=LAB04;Integrated Security=True";
        public DbContext()
        {
        }
        public List<Supplier> GetSuppliersFromDatabase()
        {
            List<Supplier> suppliers = new();

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
    }
}
