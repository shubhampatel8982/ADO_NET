using System;
using System.Collections.Generic;
using BLL;
using DT0;

namespace PL
{
    class Program
    {
        static EmployeeBLL employeeBLL = new EmployeeBLL();
        static void Main(string[] args)
        {
           
            bool running = true;

            while (running)
            {
                Console.WriteLine("Choose an option:");
                Console.WriteLine("1. Add Employee");
                Console.WriteLine("2. Update Employee");
                Console.WriteLine("3. Delete Employee");
                Console.WriteLine("4. Display All Employees");
                Console.WriteLine("5. Exit");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddEmployee();
                        break;
                    case "2":
                        UpdateEmployee();
                        break;
                    case "3":
                        DeleteEmployee();
                        break;
                    case "4":
                        DisplayAllEmployees();
                        break;
                    case "5":
                        running = false; 
                        Console.WriteLine("Exiting...");
                        break;
                    default:
                        Console.WriteLine("Invalid option.");
                        break;
                }
            }
        }

        static void AddEmployee()
        {
            try
            {
                Employee employee = GetEmployeeDetails();
                employeeBLL.AddEmployee(employee);
                Console.WriteLine("Employee added successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }

        static void UpdateEmployee()
        {
            try
            {
                Console.Write("Enter Employee ID to update: ");
                int id = int.Parse(Console.ReadLine());
                Employee employee = GetEmployeeDetails();
                employee.ID = id;
                employeeBLL.UpdateEmployee(employee);
                Console.WriteLine("Employee updated successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }

        static void DeleteEmployee()
        {
            try
            {
                Console.Write("Enter Employee ID to delete: ");
                int id = int.Parse(Console.ReadLine());
                employeeBLL.DeleteEmployee(id);
                Console.WriteLine("Employee deleted successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }

        static void DisplayAllEmployees()
        {
            List<Employee> employees = employeeBLL.GetAllEmployees();
            foreach (var employee in employees)
            {
                Console.WriteLine($"ID: {employee.ID}, Name: {employee.Name}, DateOfBirth: {employee.DateOfBirth}, DateOfJoining: {employee.DateOfJoining}, Salary: {employee.Salary}, Dept: {employee.Dept}, Password: {employee.Password}");
            }
        }

        static Employee GetEmployeeDetails()
        {
            Employee employee = new Employee();

            Console.Write("Enter Name: ");
            employee.Name = Console.ReadLine();

            Console.Write("Enter Date of Birth (YYYY-MM-DD): ");
            employee.DateOfBirth = DateTime.Parse(Console.ReadLine());

            Console.Write("Enter Date of Joining (YYYY-MM-DD): ");
            employee.DateOfJoining = DateTime.Parse(Console.ReadLine());

            Console.Write("Enter Salary (or press Enter to skip): ");
            string salaryInput = Console.ReadLine();
            employee.Salary = string.IsNullOrEmpty(salaryInput) ? (int?)null : int.Parse(salaryInput);

            Console.Write("Enter Dept (HR, Accts, IT): ");
            employee.Dept = Console.ReadLine();

            Console.Write("Enter Password: ");
            employee.Password = Console.ReadLine();

            return employee;
        }
    }
}
