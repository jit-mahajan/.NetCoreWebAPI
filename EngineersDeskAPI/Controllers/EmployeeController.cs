using DatabaseProject.Interfaces;
using DatabaseProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;

namespace EngineersDeskAPI.Controllers
{

    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepository _EmployeeRepository;

        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            _EmployeeRepository = employeeRepository;
        }

        [HttpGet]
        public ActionResult GetEmployees()
        {
            try
            {
                var employees = _EmployeeRepository.GetEmployees();
                return Ok(employees);
            }
            catch(Exception ex) { 
                 
                return StatusCode(StatusCodes.Status417ExpectationFailed, ex.Message);
            
            }
        }

        [HttpGet]
        public ActionResult GetEmployeeById(int id)
        {
            try
            {
                var employee = _EmployeeRepository.GetEmployeeById(id);
                return Ok(employee);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status417ExpectationFailed, ex.Message);
            }
        }

        [HttpPost]
        public ActionResult AddEmployee(Employee employee)
        {
            try
            {
                var addedEmployee = _EmployeeRepository.AddEmployee(employee);
                return Ok(addedEmployee);
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status417ExpectationFailed, ex.Message);
            }
        }

    }
}
