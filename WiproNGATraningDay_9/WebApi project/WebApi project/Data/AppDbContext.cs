using Microsoft.EntityFrameworkCore;
using WebApi_project.Models;

namespace WebApi_project.Data
{
  
        public class AppDbContext : DbContext
        {
            public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

            public DbSet<Batch> Batches { get; set; }

            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                modelBuilder.Entity<Batch>().HasKey(b => b.BatchId);
            }
        }


    }

