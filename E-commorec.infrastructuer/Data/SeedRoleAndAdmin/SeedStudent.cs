using E_commorec.core.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace E_commorec.infrastructuer.Data.SeedRoleAndAdmin
{
    public class SeedStudent : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.HasData(new Student
            {
                Email = "test1@gmail.com"
            ,
                Id = Guid.NewGuid(),
                FirstTimeRegister = DateTime.Now,
                Phone = "098",
                Name = "sadwa",
                Study = "",
                TypeCourse = new string[] { "test" }

            }, new Student
            {
                Email = "test31@gmail.com"
            ,
                Id = Guid.NewGuid(),
                FirstTimeRegister = DateTime.Now,
                Phone = "123123",
                Name = "asdgf",
                Study = "",
                TypeCourse = new string[] { "utyy" }

            }, new Student
            {
                Email = "test2@gmail.com"
            ,
                Id = Guid.NewGuid(),
                FirstTimeRegister = DateTime.Now,
                Phone = "098",
                Name = ",bvbnbn",
                Study = "",
                TypeCourse = new string[] { "teghjst" }

            });
        }
    }
}
