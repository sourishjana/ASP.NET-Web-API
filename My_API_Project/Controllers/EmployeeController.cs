using Microsoft.AspNetCore.Mvc;
using My_API_Project.Models;
using My_API_Project.Repository;
using System.Collections.Generic;

namespace My_API_Project.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    //[BindProperties]
    public class EmployeeController : ControllerBase
    {
        /*[HttpGet]
        public IList<Employee> getAllEmployees()
        {
            return new List<Employee>()
            {
                new Employee(){Id=1,Name="EMployee1"},
                new Employee(){Id=2,Name="EMployee2"}
            };
        }*/

        /*[HttpGet]
        [Route("{id}")]
        public IActionResult getEmployees(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }
            return Ok(new List<Employee>()
            {
                new Employee(){Id=1,Name="EMployee1"},
                new Employee(){Id=2,Name="EMployee2"}
            });
        }*/

        /*[HttpGet]
        [Route("{id}")]
        public ActionResult<IList<Employee>> getEmployees(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }
            return Ok(new List<Employee>()
            {
                new Employee(){Id=1,Name="EMployee1"},
                new Employee(){Id=2,Name="EMployee2"}
            });
        }*/

        /*[BindProperty]
        public Employee Employee { get; set; }

        [HttpPost]
        public IActionResult AddCountry()
        {
            return Ok(this.Employee);
        }*/

        /*public Employee Employee { get; set; }

        [HttpPost]
        public IActionResult AddCountry()
        {
            return Ok(this.Employee);
        }*/


        /*[HttpGet]
        public IActionResult AddCountry(string name,int id)
        {
            return Ok("Name "+name+" id "+id);
        }*/

        /*[HttpPost]
        public IActionResult AddEmployee(Employee employee)
        {
            return Ok("Name " + employee.Name + " id " + employee.Id);
        }*/

        /*[HttpPost]
        public IActionResult AddEmployee([FromBody]Employee employee,[FromHeader]string developer)
        {
            return Ok("Name " + employee.Name + " id " + employee.Id+" developer "+developer);
        }*/


        // Normal --------------------------------------------------------------------

        /*private readonly EmployeeRepository _employeeRepository;

        public EmployeeController()
        {
            _employeeRepository = new EmployeeRepository();
        }

        [HttpPost]
        public IActionResult AddEmployee([FromBody] Employee employee)
        {
            _employeeRepository.AddEmployee(employee);
            var employees = _employeeRepository.GetAllEMployees();
            return Ok(employees);
        }*/


        // Singleton service ------------------------------------------------------


        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        [HttpPost]
        public IActionResult AddEmployee([FromBody] Employee employee)
        {
            _employeeRepository.AddEmployee(employee);
            var employees = _employeeRepository.GetAllEMployees();
            return Ok(employees);
        }
    }
}
