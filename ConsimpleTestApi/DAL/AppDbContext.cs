using ConsimpleTestApi.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace ConsimpleTestApi.DAL
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        
        public DbSet<User> Users {  get; set; } 

        public DbSet<Purchase> Purchases {  get; set; } 

        public DbSet<Product> Products {  get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
