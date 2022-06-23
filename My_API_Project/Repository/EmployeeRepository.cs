using System.Collections.Generic;
using My_API_Project.Models;

namespace My_API_Project.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private List<Employee> employees = new List<Employee>();
        public int AddEmployee(Employee employee)
        {
            employee.Id = employees.Count + 1;
            employees.Add(employee);
            return employee.Id;
        }
        public IList<Employee> GetAllEMployees()
        {
            return employees;
        }
    }
}
