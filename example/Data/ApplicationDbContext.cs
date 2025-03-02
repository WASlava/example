using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using example.Models;

namespace example.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
    }


}

