using System.Collections.Generic;
using My_API_Project.Models;

namespace My_API_Project.Repository
{
    public class TestRepository : IEmployeeRepository
    {
        public int AddEmployee(Employee employee)
        {
            throw new System.NotImplementedException();
        }

        public IList<Employee> GetAllEMployees()
        {
            throw new System.NotImplementedException();
        }

        public string GetName()
        {
            return "Name from Test Repository";
        }
    }
}
