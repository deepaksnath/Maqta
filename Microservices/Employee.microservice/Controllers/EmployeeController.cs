using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Employee_microservice.Models;
using Serilog;

namespace Employee_microservice.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly ILogger<EmployeeService> _logger;
        private readonly IEmployeeService employeeService;

        public EmployeeController(ILogger<EmployeeService> logger, IEmployeeService employeeService)
        {
            this._logger = logger;
            this.employeeService = employeeService;
        }

        [HttpGet]
        public IEnumerable<Employee> Get()
        {
            try
            {
                return this.employeeService.GetAllEmployees();
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                throw e;
            }
        }

        [HttpGet("{id}")]
        public Employee Get(int id)
        {
            try
            {
                return this.employeeService.GetEmployee(id);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                throw e;
            }
        }

        [HttpPost]
        public Employee Post(Employee employee)
        {
            try
            {
                return this.employeeService.CreateEmployee(employee);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                throw e;
            }
        }

        [HttpPut]
        public Employee Put(Employee employee)
        {
            try
            {
                return this.employeeService.UpdateEmployee(employee);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                throw e;
            }
        }

        [HttpDelete("{id}")]
        public int Delete(int id)
        {
            try
            {
                return this.employeeService.DeleteEmployee(id);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                throw e;
            }
        }
    }
}
