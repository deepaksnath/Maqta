using Employee_microservice.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Employee_microservice
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IUnitOfWork unitOfWork;

        public EmployeeService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public Employee CreateEmployee(Employee employee)
        {
            try
            {
                this.unitOfWork.EmployeeRepository.Insert(employee);
                this.unitOfWork.Save();
                return employee;
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        public int DeleteEmployee(int id)
        {
            try
            {
                this.unitOfWork.EmployeeRepository.Delete(new Employee { Id = id });
                this.unitOfWork.Save();
                return id;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public IEnumerable<Employee> GetAllEmployees()
        {
            try
            {
                return this.unitOfWork.EmployeeRepository.Get();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public Employee GetEmployee(int id)
        {
            try
            {
                return this.unitOfWork.EmployeeRepository.GetByID(id);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public Employee UpdateEmployee(Employee employee)
        {
            try
            {
                this.unitOfWork.EmployeeRepository.Update(employee);
                this.unitOfWork.Save();
                return employee;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
