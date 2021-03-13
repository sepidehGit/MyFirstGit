using Microsoft.EntityFrameworkCore;
using MyAzurTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyAzurTest.Data
{
    public class ApplicationDBContext :DbContext 
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options)
            : base(options)
        {
        }
        
        public virtual DbSet<EmployeeModel> Employee { get; set; }

    }
}
