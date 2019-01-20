using Dropdownlistmvc.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Dropdownlistmvc.Data;

namespace Dropdownlistmvc.Repository
{
    public class EmployeeRepository : IEmployee
    {
        readonly EFDbContext _context = new EFDbContext();
        public IList<Employee> GetEmployees => _context.Employees.ToList<Employee>();

        public void Delete(int? id)
        {
            Employee emp = _context.Employees.Find(id);
            if(emp != null)
            {
                _context.Employees.Remove(emp);
                _context.SaveChanges();
            }

        }

        public Employee GetEmployee(int? Id)
        {
            return _context.Employees.Find(Id);
        }

        public void Save(Employee employee)
        {
            if (employee.Id == 0)
            {
                _context.Employees.Add(employee);
                _context.SaveChanges();
            }
            else
            {
                Employee dbEntry = _context.Employees.Find(employee.Id);
                dbEntry.Id = employee.Id;
                dbEntry.FirstName = employee.FirstName;
                dbEntry.LastName = employee.LastName;
                dbEntry.GenderId = employee.GenderId;
                dbEntry.Salary = employee.Salary;
                _context.SaveChanges();
            }
        }
    }
}