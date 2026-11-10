using FleetOne.Entities;
using Microsoft.EntityFrameworkCore;

namespace FleetOne.Data;

    // 1. The 'primary' constructor passes the database options (like connection strings) to EF Core
public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
    // 2. These DbSets represent your database tables
    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder); // Good practice to keep, especially if using Identity

        modelBuilder.Entity<User>()
            .Property(u => u.UserId)
            .HasDefaultValueSql("gen_random_uuid()"); 
    }
}