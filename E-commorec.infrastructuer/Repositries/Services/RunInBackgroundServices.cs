using E_commorec.core.Entity;
using E_commorec.infrastructuer.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace E_commorec.core.Services
{
    public class RunInBackgroundServices : BackgroundService
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly AppDbContext context;
        public RunInBackgroundServices(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                await ProcessCompletionAsync();
                await Task.Delay(TimeSpan.FromDays(1), stoppingToken);
            }
        }

        private async Task ProcessCompletionAsync()
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                AppDbContext context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
                //  CreateCertificate(context);

            }
            await Task.CompletedTask;
        }

        private void CreateCertificate(AppDbContext context)
        {

            List<SubCourse> getCourses = context.Subcourses
                .Include(m => m.Course)
                .Include(m => m.StudentSubCourses)
                .AsNoTracking()
                .ToList();

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
                context.Certificates.AddRange(certificates);
                context.SaveChanges();

            }
        }


    }
}

