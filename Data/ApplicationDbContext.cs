using FluentApi.Models;
using Microsoft.EntityFrameworkCore;

namespace FluentApi.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Department> Departments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("User_Info");
            modelBuilder.Entity<User>().
                HasOne(x => x.Department).
                WithMany(x => x.Users).HasForeignKey(x => x.DepartmentId).IsRequired();

            modelBuilder.Entity<Department>().
                HasMany(x => x.Users).
                WithOne(x => x.Department).
                OnDelete(DeleteBehavior.Cascade);

            base.OnModelCreating(modelBuilder);
        }
    }
}
