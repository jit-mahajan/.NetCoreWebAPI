using DatabaseProject.DatabaseContext;
using DatabaseProject.Interfaces;
using DatabaseProject.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseProject.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {

        private readonly SqlServerContext _SqlServerContext;

        public EmployeeRepository(SqlServerContext sqlServerContext)
        {
                _SqlServerContext = sqlServerContext;
        }



        public Employee AddEmployee(Employee employee)
        {
            _SqlServerContext.Employee.Add(employee);
            _SqlServerContext.SaveChanges();
            return employee; 
            
        }

        public Employee GetEmployeeById(int id)
        {
            var employee = _SqlServerContext.Employee.Where(e => e.EmployeeId == id).FirstOrDefault();

            return employee;
        }

        public List<Employee> GetEmployees()
        {
            var empList = _SqlServerContext.Employee.ToList();
            return empList;
        }
    }
}
