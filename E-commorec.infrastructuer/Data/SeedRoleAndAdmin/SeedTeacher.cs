using E_commorec.core.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace E_commorec.infrastructuer.Data.SeedRoleAndAdmin
{
    public class SeedTeacher : IEntityTypeConfiguration<Teacher>
    {
        public void Configure(EntityTypeBuilder<Teacher> builder)
        {
            builder.HasData(
            new Teacher
            {

                Email = "test1@gmail.com"
            ,
                Id = Guid.NewGuid(),
                FirstTimeRegister = DateTime.Now,
                Phone = "098"
            ,
                LevelOfStudy = "string",
                Position = "stro",
                Name = "sadwa",
                TimeToResign = DateTime.Now
                ,

            }, new Teacher
            {
                Email = "test2@gmail.com"
            ,
                Id = Guid.NewGuid(),
                FirstTimeRegister = DateTime.Now,
                Phone = "0981"
            ,
                LevelOfStudy = "str2ing",
                Position = "s3tro",
                Name = "s1adwa",
                TimeToResign = DateTime.Now
                ,

            });
        }
    }
}
