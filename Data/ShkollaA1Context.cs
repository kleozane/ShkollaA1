using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ShkollaA1.Models;

namespace ShkollaA1.Data
{
    public class ShkollaA1Context : DbContext
    {
        public ShkollaA1Context (DbContextOptions<ShkollaA1Context> options)
            : base(options)
        {
        }

        public DbSet<ShkollaA1.Models.Teacher> Teacher { get; set; } = default!;
        public DbSet<ShkollaA1.Models.Subject> Subjects { get; set; } = default!;
    }
}
