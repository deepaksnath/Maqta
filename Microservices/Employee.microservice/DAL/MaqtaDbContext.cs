using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Employee_microservice.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Employee_microservice
{
    public class MaqtaDbContext : DbContext
    {
        public MaqtaDbContext(DbContextOptions<MaqtaDbContext> options)
            : base(options)
        {

        }
        public DbSet<Employee> Employees { get; set; }
       
    }
}
