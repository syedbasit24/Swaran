using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Swaran.Models
{
    public class StudentDbContext
    {
        public DbSet<Student> Students { get; set; }

        public DbSet<State> States { get; set; }

        public DbSet<City> Cities { get; set; }

      
    }
}
