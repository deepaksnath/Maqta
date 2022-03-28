using Employee_microservice.Interfaces;
using Employee_microservice.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Employee_microservice
{
    public class UnitOfWork : IDisposable, IUnitOfWork
    {
        private readonly MaqtaDbContext context;
        private GenericRepository<Employee> employeeRepository;

        public UnitOfWork(MaqtaDbContext _context)
        {
            context = _context;
        }
        public GenericRepository<Employee> EmployeeRepository
        {
            get
            {
                if (this.employeeRepository == null)
                {
                    this.employeeRepository = new GenericRepository<Employee>(context);
                }
                return employeeRepository;
            }
        }
      
        public void Save()
        {
            context.SaveChanges();
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }
    }
}
