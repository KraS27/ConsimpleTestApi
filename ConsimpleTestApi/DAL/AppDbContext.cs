using ConsimpleTestApi.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace ConsimpleTestApi.DAL
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        
        public DbSet<UserEntity> Users {  get; set; } 

        public DbSet<PurchaseEntity> Purchases {  get; set; } 

        public DbSet<ProductEntity> Products {  get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
