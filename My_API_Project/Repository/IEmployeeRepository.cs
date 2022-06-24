using My_API_Project.Models;
using System.Collections.Generic;

namespace My_API_Project.Repository
{
    public interface IEmployeeRepository
    {
        int AddEmployee(Employee employee);
        IList<Employee> GetAllEMployees();

        public string GetName();
    }
}