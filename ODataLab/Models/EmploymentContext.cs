using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ODataLab.Models
{
    class EmploymentContext : DbContext
    {
        public EmploymentContext() 
                : base("name=EmploymentContext")
        {
        }
        public DbSet<Employment> Employments { get; set; }
    }
}
