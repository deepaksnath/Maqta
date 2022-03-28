using Employee_microservice.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Employee_microservice
{
    public interface IUnitOfWork
    {
        GenericRepository<Employee> EmployeeRepository { get; }

        void Dispose();
        void Save();
    }
}
