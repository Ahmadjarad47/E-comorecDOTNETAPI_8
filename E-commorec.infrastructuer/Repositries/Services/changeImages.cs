using E_commorec.core.Entity;
using E_commorec.infrastructuer.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commorec.core.Services
{
    public class changeImages : BackgroundService
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly AppDbContext context;
        public changeImages(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                await ProcessCourseCompletionAsync();
                await Task.Delay(TimeSpan.FromDays(1), stoppingToken); // Check every 5 minutes
            }
        }

        private async Task ProcessCourseCompletionAsync()
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                AppDbContext context = scope.ServiceProvider.GetRequiredService<AppDbContext>();

                List<SubCourse> getCourses = await context.Subcourses
                    .Include(m => m.Course)
                    .Include(m => m.StudentSubCourses)
                    .AsNoTracking()
                    .ToListAsync();

                if (getCourses.Count > 0)
                {


                    List<Certificate> certificates = new();
                    foreach (var item in getCourses)
                    {
                        if (item.TotalHour <= item.Hourscompleted)
                        {

                            var certifcate = new Certificate()
                            {
                                Name = string.Empty,
                                Description = string.Empty,
                                State = Degree.pending,
                                StudentId = item.StudentSubCourses.FirstOrDefault(m => m.SubCourseId == item.Id).StudentId,
                                SubCourseId = item.Id,

                            };
                            certificates.Add(certifcate);
                        }
                    }
                    await context.Certificates.AddRangeAsync(certificates);
                    await context.SaveChangesAsync();

                }
            }
            await Task.CompletedTask;
        }

    }
}

//var students = await context.Students.Include(m => m.StudentSubCourses)
//    .ToListAsync();

//foreach (var item in students)
//{
//    if (string.IsNullOrEmpty(item.Image))
//    {
//        Random random = new Random();
//        if (item.Gender == 0)
//        {
//            item.Image = $"/Images/Female/{random.Next(1, 15)}.png";
//        }
//        else
//        {
//            item.Image = $"/Images/Male/{random.Next(1, 18)}.png";
//        }
//    }
//}

//// Update student records in the database
//context.Students.UpdateRange(students);
//await context.SaveChangesAsync();