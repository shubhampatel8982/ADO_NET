using System.Collections.Generic;
using DAL;
using DT0;

namespace BLL
{
    public class EmployeeBLL
    {
        private EmployeeDAL employeeDAL = new EmployeeDAL();

        public List<Employee> GetAllEmployees()
        {
            return employeeDAL.GetAllEmployees();
        }

        public void AddEmployee(Employee employee)
        {
            ValidateEmployee(employee); 
            employeeDAL.AddEmployee(employee);
        }

        public void UpdateEmployee(Employee employee)
        {
            ValidateEmployee(employee); 
            employeeDAL.UpdateEmployee(employee);
        }

        public void DeleteEmployee(int id)
        {
            employeeDAL.DeleteEmployee(id);
        }

        private void ValidateEmployee(Employee employee)
        {
            
            if (string.IsNullOrEmpty(employee.Name) || employee.Name.Length < 15)
                throw new ArgumentException("Name must be at least 15 characters long.");
            if (employee.DateOfBirth.Year < 2002 || employee.DateOfBirth.Year > 2005)
                throw new ArgumentException("Year of Birth must be between 2002 and 2005.");
            if (employee.DateOfJoining > DateTime.Now)
                throw new ArgumentException("Date of Joining cannot be in the future.");
            if (employee.Salary.HasValue && (employee.Salary < 12000 || employee.Salary > 60000))
                throw new ArgumentException("Salary must be between 12000 and 60000.");
            if (employee.Dept != "HR" && employee.Dept != "Accts" && employee.Dept != "IT")
                throw new ArgumentException("Department must be HR, Accts, or IT.");
            if (string.IsNullOrEmpty(employee.Password))
                throw new ArgumentException("Password must not be empty.");
        }
    }
}
