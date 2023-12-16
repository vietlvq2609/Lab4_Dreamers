

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
                                SupplierName = reader.GetString(reader.GetOrdinal("SupplierName")),
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
        //update supplier
        public void UpdateSupplier(Supplier supplier)
        {
            using (SqlConnection connection = new(this.connectionString))
            {
                connection.Open();

                string query = "UPDATE Suppliers SET CompanyName = @CompanyName, ContactName = @ContactName, SupplierName = @SupplierName, Address = @Address, City = @City, Country = @Country WHERE SupplierID = @SupplierID";

                using (SqlCommand command = new(query, connection))
                {
                    command.Parameters.AddWithValue("@CompanyName", supplier.CompanyName);
                    command.Parameters.AddWithValue("@ContactName", supplier.ContactName);
                    command.Parameters.AddWithValue("@SupplierName", supplier.SupplierName);
                    command.Parameters.AddWithValue("@Address", supplier.Address);
                    command.Parameters.AddWithValue("@City", supplier.City);
                    command.Parameters.AddWithValue("@Country", supplier.Country);
                    command.Parameters.AddWithValue("@SupplierID", supplier.SupplierID);

                    command.ExecuteNonQuery();
                }
            }
        }
        //delete supplier
        public void DeleteSupplier(int id)
        {
            using (SqlConnection connection = new(this.connectionString))
            {
                connection.Open();

                string query = "DELETE FROM Suppliers WHERE SupplierID = @SupplierID";

                using (SqlCommand command = new(query, connection))
                {
                    command.Parameters.AddWithValue("@SupplierID", id);

                    command.ExecuteNonQuery();
                }
            }
        }
        //add supplier
        public void AddSupplier(Supplier supplier)
        {
            using (SqlConnection connection = new(this.connectionString))
            {
                connection.Open();

                string query = "INSERT INTO Suppliers (CompanyName, ContactName, SupplierName, Address, City, Country) VALUES (@CompanyName, @ContactName, @SupplierName, @Address, @City, @Country)";

                using (SqlCommand command = new(query, connection))
                {
                    command.Parameters.AddWithValue("@CompanyName", supplier.CompanyName);
                    command.Parameters.AddWithValue("@ContactName", supplier.ContactName);
                    command.Parameters.AddWithValue("@SupplierName", supplier.SupplierName);
                    command.Parameters.AddWithValue("@Address", supplier.Address);
                    command.Parameters.AddWithValue("@City", supplier.City);
                    command.Parameters.AddWithValue("@Country", supplier.Country);

                    command.ExecuteNonQuery();
                }
            }
        }

        public List<Employee> GetEmployeesFromDatabase()
        {
            List<Employee> employees = new();

            using (SqlConnection connection = new(this.connectionString))
            {
                connection.Open();

                string query = "SELECT * FROM Employees";

                using (SqlCommand command = new(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Employee employee = new()
                            {
                                EmployeeID = reader.GetInt32(reader.GetOrdinal("EmployeeID")),
                                LastName = reader.GetString(reader.GetOrdinal("LastName")),
                                FirstName = reader.GetString(reader.GetOrdinal("FirstName")),
                                JobTitle = reader.GetString(reader.GetOrdinal("JobTitle")),
                                PrimaryPhone = reader.GetString(reader.GetOrdinal("PrimaryPhone")),
                            };

                            employees.Add(employee);
                        }
                    }
                }
            }

            return employees;
        }
        //update employee
        public void UpdateEmployee(Employee employee)
        {
            using (SqlConnection connection = new(this.connectionString))
            {
                connection.Open();

                string query = "UPDATE Employees SET LastName = @LastName, FirstName = @FirstName, JobTitle = @JobTitle, PrimaryPhone = @PrimaryPhone WHERE EmployeeID = @EmployeeID";

                using (SqlCommand command = new(query, connection))
                {
                    command.Parameters.AddWithValue("@LastName", employee.LastName);
                    command.Parameters.AddWithValue("@FirstName", employee.FirstName);
                    command.Parameters.AddWithValue("@JobTitle", employee.JobTitle);
                    command.Parameters.AddWithValue("@PrimaryPhone", employee.PrimaryPhone);
                    command.Parameters.AddWithValue("@EmployeeID", employee.EmployeeID);

                    command.ExecuteNonQuery();
                }
            }
        }
        //delete employee
        public void DeleteEmployee(int id)
        {
            using (SqlConnection connection = new(this.connectionString))
            {
                connection.Open();

                string query = "DELETE FROM Employees WHERE EmployeeID = @EmployeeID";

                using (SqlCommand command = new(query, connection))
                {
                    command.Parameters.AddWithValue("@EmployeeID", id);

                    command.ExecuteNonQuery();
                }
            }
        }
        //add employee
        public void AddEmployee(Employee employee)
        {
            using (SqlConnection connection = new(this.connectionString))
            {
                connection.Open();

                string query = "INSERT INTO Employees (LastName, FirstName, JobTitle, PrimaryPhone) VALUES (@LastName, @FirstName, @JobTitle, @PrimaryPhone)";

                using (SqlCommand command = new(query, connection))
                {
                    command.Parameters.AddWithValue("@LastName", employee.LastName);
                    command.Parameters.AddWithValue("@FirstName", employee.FirstName);
                    command.Parameters.AddWithValue("@JobTitle", employee.JobTitle);
                    command.Parameters.AddWithValue("@PrimaryPhone", employee.PrimaryPhone);

                    command.ExecuteNonQuery();
                }
            }
        }

    }
}
