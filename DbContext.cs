

using Lab4_Dreamers.Models;
using System.Data.SqlClient;

namespace Lab4_Dreamers
{
    public class DbContext
    {
        private string connectionString = "Server=(localdb)\\mssqllocaldb;Database=DreamerLab4;Trusted_Connection=True;";
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

    }
}
