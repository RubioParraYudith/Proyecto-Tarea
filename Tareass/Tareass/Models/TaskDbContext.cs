using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Tareass.Models
{
    public class TaskDbContext:DbContext
    {
        public TaskDbContext():base("MyConnection")
        {

        }

        public DbSet<Task> Tasks { get; set; }
        public DbSet<User> Users { get; set; }
    }
}