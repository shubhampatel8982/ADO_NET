using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using DT0;

namespace DAL
{
    public class EmployeeDAL
    {
        private string connectionString = "Server=DESKTOP-L2IM416;Database=PractDB;User Id=sa;Password=YourStrong@Passw0rd;TrustServerCertificate=True;";

        public List<Employee> GetAllEmployees()
        {
            List<Employee> employees = new List<Employee>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM Employees", conn); 
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    employees.Add(new Employee
                    {
                        ID = Convert.ToInt32(reader["ID"]),
                        Name = reader["Name"].ToString(),
                        DateOfBirth = Convert.ToDateTime(reader["DateOfBirth"]),
                        DateOfJoining = Convert.ToDateTime(reader["DateOfJoining"]),
                        Salary = reader["Salary"] != DBNull.Value ? Convert.ToInt32(reader["Salary"]) : (int?)null,
                        Dept = reader["Dept"].ToString(),
                        Password = reader["Password"].ToString()
                    });
                }
            }

            return employees;
        }

        public void AddEmployee(Employee employee)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO Employees (Name, DateOfBirth, DateOfJoining, Salary, Dept, Password) VALUES (@Name, @DateOfBirth, @DateOfJoining, @Salary, @Dept, @Password)", conn); // Changed from 'emp' to 'Employees'
                cmd.Parameters.AddWithValue("@Name", employee.Name);
                cmd.Parameters.AddWithValue("@DateOfBirth", employee.DateOfBirth);
                cmd.Parameters.AddWithValue("@DateOfJoining", employee.DateOfJoining);
                cmd.Parameters.AddWithValue("@Salary", employee.Salary.HasValue ? (object)employee.Salary.Value : DBNull.Value);
                cmd.Parameters.AddWithValue("@Dept", employee.Dept);
                cmd.Parameters.AddWithValue("@Password", employee.Password);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void UpdateEmployee(Employee employee)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("UPDATE Employees SET Name = @Name, DateOfBirth = @DateOfBirth, DateOfJoining = @DateOfJoining, Salary = @Salary, Dept = @Dept, Password = @Password WHERE ID = @ID", conn); // Changed from 'emp' to 'Employees'
                cmd.Parameters.AddWithValue("@ID", employee.ID);
                cmd.Parameters.AddWithValue("@Name", employee.Name);
                cmd.Parameters.AddWithValue("@DateOfBirth", employee.DateOfBirth);
                cmd.Parameters.AddWithValue("@DateOfJoining", employee.DateOfJoining);
                cmd.Parameters.AddWithValue("@Salary", employee.Salary.HasValue ? (object)employee.Salary.Value : DBNull.Value);
                cmd.Parameters.AddWithValue("@Dept", employee.Dept);
                cmd.Parameters.AddWithValue("@Password", employee.Password);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void DeleteEmployee(int id)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("DELETE FROM Employees WHERE ID = @ID", conn); 
                cmd.Parameters.AddWithValue("@ID", id);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
