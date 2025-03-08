using System.Collections.Generic;
using System.Linq;
using EmployeeManagement.DAL;
using EmployeeManagement.Models;

namespace EmployeeManagement.BLL
{
    public class EmployeeService
    {
        private readonly ApplicationDbContext _context;

        public EmployeeService(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Employee> GetAllEmployees()
        {
            return _context.Employees.ToList();
        }

        public Employee GetEmployeeById(int id)
        {
            return _context.Employees.Find(id);
        }

        public void AddEmployee(Employee emp)
        {
            
            if (string.IsNullOrEmpty(emp.Password))
            {
                emp.Password = "defaultPassword"; 
            }

            _context.Employees.Add(emp);
            _context.SaveChanges();
        }


        public void UpdateEmployee(Employee emp)
        {
            _context.Employees.Update(emp);
            _context.SaveChanges();
        }

        public void DeleteEmployee(int id)
        {
            var emp = _context.Employees.Find(id);
            if (emp != null)
            {
                _context.Employees.Remove(emp);
                _context.SaveChanges();
            }
        }
    }
}
