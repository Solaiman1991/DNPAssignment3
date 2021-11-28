using Assignment2.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Assignment2.DataAccess
{
    public class DatabaseContext: DbContext

    {
    public DbSet<Adult> Adults { get; set; }
    public DbSet<User> Users { get; set; }


    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite(@"Data source = C:\Users\Solaiman\RiderProjects\Assignment2\Assignment3\Adult.db");
    }
    }
}