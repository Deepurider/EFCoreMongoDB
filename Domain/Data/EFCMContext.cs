using Domain.Models;
using Microsoft.EntityFrameworkCore;
using MongoDB.Bson;
using MongoDB.EntityFrameworkCore.Extensions;


namespace Domain.Data
{
    public class EFCMContext : DbContext
    {
        public DbSet<User> Users { get; init; }

        public DbSet<Employee> Employees { get; init; }

        public EFCMContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToCollection("users");
            modelBuilder.Entity<User>().Property(x => x.Id).HasConversion<ObjectId>();

            modelBuilder.Entity<Employee>().ToCollection("employees");
            modelBuilder.Entity<Employee>().Property(x => x.Id).HasConversion<ObjectId>();

            base.OnModelCreating(modelBuilder);
        }
    }
}
