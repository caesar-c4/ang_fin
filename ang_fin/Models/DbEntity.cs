using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ang_fin.Models
{
    public class DbEntity : DbContext
    {
        public DbEntity() : base("ang_fin")
        {

        }
        public DbSet<Employee> Employees { get; set; }
    }
}