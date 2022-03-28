using Employee_microservice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Employee_microservice
{
    public interface IEmployeeService
    {
        Employee GetEmployee(int id);
        IEnumerable<Employee> GetAllEmployees();
        Employee CreateEmployee(Employee employee);
        Employee UpdateEmployee(Employee employee);
        int DeleteEmployee(int id);
    }
}
