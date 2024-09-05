using E_commorec.core.Entity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;


namespace E_commorec.infrastructuer.Data
{
    public class AppDbContext : IdentityDbContext<AppUsers>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public virtual DbSet<AppUsers> AppUsers { get; set; }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<Teacher> Teachers { get; set; }
        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<SubCourse> Subcourses { get; set; }
        public virtual DbSet<StudentSubCourse> StudentSubCourses { get; set; }

        public virtual DbSet<Certificate> Certificates { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
