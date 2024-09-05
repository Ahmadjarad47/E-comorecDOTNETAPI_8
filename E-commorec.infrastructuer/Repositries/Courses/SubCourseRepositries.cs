using AutoMapper;
using E_commorec.core.DTO.Course;
using E_commorec.core.Entity;
using E_commorec.core.InterFace;
using E_commorec.infrastructuer.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.FileProviders;


namespace E_commorec.infrastructuer.Repositries.Courses
{
    public class SubCourseRepositries : GenericRepositries<SubCourse>, ISubCourse
    {
        private readonly AppDbContext context;
        private readonly IMemoryCache memoryCache;
        private readonly IMapper mapper;
        private readonly IFileProvider fileProvider;
        public SubCourseRepositries(AppDbContext context, IMemoryCache memoryCache, IMapper mapper, IFileProvider fileProvider) : base(context, memoryCache)
        {
            this.memoryCache = memoryCache;
            this.context = context;
            this.mapper = mapper;
            this.fileProvider = fileProvider;
        }



        public async Task<IReadOnlyList<ReturnSubCourse>> GetAllAsync()
        {
            var getValueFromMemory = memoryCache.TryGetValue("ListSubCourse", out List<ReturnSubCourse> cache);
            if (getValueFromMemory)
                return cache.AsReadOnly();

            var returnSubCourses = await context.Subcourses
                .Include(m => m.Teacher)
                .Include(m => m.Course)
                .Include(m => m.StudentSubCourses)
                    .ThenInclude(ssc => ssc.Student)
                .AsNoTracking()
                .Select(item => new ReturnSubCourse
                {
                    CourseName = item.Course.Name,
                    Name = item.Name,
                    Day = item.Day,
                    Id = item.Id,
                    Price = item.Price,
                    Hourscompleted = item.Hourscompleted,
                    TimeHouerFromTo = item.TimeHouerFromTo,
                    TimeOfLectuer = item.TimeOfLectuer,
                    TotalHour = item.TotalHour,
                    TeacherName = item.Teacher.Name,
                    TeacherId = item.Teacher.Id,
                    Image = item.Image,
                    studentSubs = item.StudentSubCourses
                        .Select(ssc => new StudentSub
                        {
                            Id = ssc.Student.Id,
                            Name = ssc.Student.Name
                        }).ToList()

                }).ToListAsync();

            memoryCache.Set<List<ReturnSubCourse>>("ListSubCourse", returnSubCourses,
                DateTime.Now.AddHours(5));
            return returnSubCourses;

        }










        public async Task<ReturnSubCourse> GetByIdAsync(int id)
        {
            return await context.Subcourses

               .Include(m => m.Teacher)
               .Include(m => m.Course)
               .Include(m => m.StudentSubCourses)
                   .ThenInclude(ssc => ssc.Student)
               .AsNoTracking()
               .Select(item => new ReturnSubCourse
               {
                   CourseName = item.Course.Name,
                   Name = item.Name,
                   Day = item.Day,
                   Id = item.Id,
                   Price = item.Price,
                   Hourscompleted = item.Hourscompleted,
                   TimeHouerFromTo = item.TimeHouerFromTo,
                   TimeOfLectuer = item.TimeOfLectuer,
                   TotalHour = item.TotalHour,
                   TeacherName = item.Teacher.Name,
                   TeacherId = item.Teacher.Id,
                   Image = item.Image,
                   studentSubs = item.StudentSubCourses
                       .Select(ssc => new StudentSub
                       {
                           Id = ssc.Student.Id,
                           Name = ssc.Student.Name
                       }).ToList()
               }).FirstOrDefaultAsync(m => m.Id == id);

        }














        public async Task<bool> AddAsync(CreateSubCourse createSubCourse)
        {
            var getTeachers = context.Teachers
                .Where(m => m.Id == createSubCourse.TeacherId).AsNoTracking();
            if (getTeachers is null)
            {
                return false;
            }
            string ImageSRC = "";
            if (createSubCourse.Image.Length > 0)
            {
                var ImageDirctory = Path.Combine("wwwroot", "Images", "SubCourse");

                if (Directory.Exists(ImageDirctory) is not true)
                {
                    Directory.CreateDirectory(ImageDirctory);
                }
                var ImageName = createSubCourse.Image.FileName;
                ImageSRC = $"/Images/SubCourse/{ImageName}";
                var root = Path.Combine(ImageDirctory, ImageName);
                using (FileStream stream = new FileStream(root, FileMode.Create))
                {
                    await createSubCourse.Image.CopyToAsync(stream);
                }


            }
            var newSub = new SubCourse()
            {
                CourseId = createSubCourse.CourseId,
                Day = createSubCourse.Day,
                Hourscompleted = createSubCourse.Hourscompleted,
                Name = createSubCourse.Name,
                TeacherId = createSubCourse.TeacherId,
                TotalHour = createSubCourse.TotalHour,
                TimeOfLectuer = createSubCourse.TimeOfLectuer,
                TimeHouerFromTo = createSubCourse.TimeHouerFromTo,
                Price = createSubCourse.Price,
                Image = ImageSRC,
            };
            context.Entry(newSub).State = EntityState.Added;
            await context.SaveChangesAsync();
            memoryCache.Remove("ListSubCourse");
            return true;

        }






        public async Task<bool> UpdateStudentAsync(AddORStudentCourse sameCourse)
        {
            var findCourse = await context.Subcourses
                .Where(m => m.Id == sameCourse.Id)
                .AsNoTracking()
                .FirstOrDefaultAsync();

            if (findCourse is null)
            {
                return false;
            }
            var studentSubCourses = await context.StudentSubCourses
                .Where(m => m.SubCourseId == findCourse.Id)
                .ToListAsync();

            // Retrieve the students to add from the database
            var studentsToAdd = await context.Students
                .Where(s => sameCourse.StudentId.Contains(s.Id))
               .AsNoTracking().ToListAsync();

            foreach (var studentId in studentsToAdd.Select(s => s.Id))
            {
                if (studentSubCourses.Where(m => studentId == m.StudentId).Count() > 0)
                {
                    continue;
                }
                var studentCourse = new StudentSubCourse
                {
                    SubCourseId = findCourse.Id,
                    StudentId = studentId
                };

                context.StudentSubCourses.Add(studentCourse);
            }
            await context.SaveChangesAsync();

            memoryCache.Remove("ListSubCourse");

            return true;
        }


        public async Task<bool> DeleteStudentAsync(AddORStudentCourse course)
        {
            var Students = await context.StudentSubCourses.
                Include(m => m.SubCourse).
                Include(m => m.Student).
                Where(m => course.StudentId.Contains(m.StudentId) && m.SubCourseId == course.Id)
                .ToListAsync();
            context.StudentSubCourses.RemoveRange(Students);
            await context.SaveChangesAsync();
            memoryCache.Remove("ListSubCourse");
            return true;
        }


        public async Task<bool> UpdateAsync(UpdateProprties sameCourse)
        {
            var findCourse = await context.Subcourses
                .Include(m => m.Teacher)
                .Include(m => m.Course)
                .Include(m => m.StudentSubCourses)
                .ThenInclude(ssc => ssc.Student)
                .FirstOrDefaultAsync(m => m.Id == sameCourse.Id);

            if (findCourse == null)
            {
                // Handle case where course is not found
                return false;
            }

            // Map properties from sameCourse to findCourse (except Image)

            string ImageSRC = findCourse.Image; // Keep the existing image if none is provided

            if (sameCourse.Image != null && sameCourse.Image.Length > 0)
            {
                // Delete the existing image if it exists
                IFileInfo info = fileProvider.GetFileInfo(findCourse.Image);

                File.Delete(path: info.PhysicalPath);


                string ImageDirectory = Path.Combine("wwwroot", "Images", "SubCourse");

                // Ensure the directory exists
                if (!Directory.Exists(ImageDirectory))
                {
                    Directory.CreateDirectory(ImageDirectory);
                }

                string ImageName = Path.GetFileName(sameCourse.Image.FileName);
                ImageSRC = $"/Images/SubCourse/{ImageName}";
                string root = Path.Combine(ImageDirectory, ImageName);

                // Save the new image to the server
                using (FileStream stream = new FileStream(root, FileMode.Create))
                {
                    await sameCourse.Image.CopyToAsync(stream);
                }

                // Update the course image path

            }
            mapper.Map(sameCourse, findCourse);
            findCourse.Image = ImageSRC;
            context.Subcourses.Update(findCourse);
            await context.SaveChangesAsync();

            // Clear the cache
            memoryCache.Remove("ListSubCourse");

            return true;
        }



    }
}
