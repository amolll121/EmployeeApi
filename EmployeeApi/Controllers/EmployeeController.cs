using EmployeeApi.Models;
using Microsoft.AspNetCore.Mvc;
using EmployeeApi.Data;
using Microsoft.EntityFrameworkCore;

namespace EmployeeApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly AppDbContext _context;

        public EmployeeController(AppDbContext context)
        {
            _context = context;
        }

        //[HttpGet]
        //public IEnumerable<Employee> GetEmployees()
        //{
        //    return new List<Employee>
        //    {
        //        new Employee { Id = 1, Name = "Amol", Age = 25, Salary = 25000 },
        //        new Employee { Id = 2, Name = "Rahul", Age = 28, Salary = 30000 }
        //    };
        //}

        [HttpGet]
        public async Task<List<Employee>> GetEmployees()
        {
            return await _context.Employees.ToListAsync();
        }

        //[HttpPost]
        //public Employee AddEmployee(Employee employee)
        //{
        //    return employee;
        //}

        [HttpPost]
        public async Task<Employee> AddEmployee(Employee employee)
        {
            _context.Employees.Add(employee);

            await _context.SaveChangesAsync();

            return employee;
        }


        [HttpPut("{id}")]
        public async Task<Employee> UpdateEmployee(int id, Employee employee)
        {
            var existingEmployee = await _context.Employees.FindAsync(id);

            existingEmployee.Name = employee.Name;
            existingEmployee.Age = employee.Age;
            existingEmployee.Salary = employee.Salary;

            await _context.SaveChangesAsync();

            return existingEmployee;
        }



    }
}