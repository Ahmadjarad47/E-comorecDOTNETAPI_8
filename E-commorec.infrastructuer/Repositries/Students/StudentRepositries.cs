using E_commorec.core.DTO.Student;
using E_commorec.core.Entity;
using E_commorec.core.InterFace;
using E_commorec.infrastructuer.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;

namespace E_commorec.infrastructuer.Repositries.Students
{
    internal class StudentRepositries : GenericRepositries<Student>, IStudent
    {
        private readonly AppDbContext context;

        public StudentRepositries(AppDbContext context, IMemoryCache memoryCache) : base(context, memoryCache)
        {
            this.context = context;
        }

        public async Task<IReadOnlyList<ReturnStudentDTO>> GetAllAsyncWithSubCourse()
        {
            return await context.Students.Include(m => m.StudentSubCourses)
                .AsNoTracking()
                .Select(m => new ReturnStudentDTO
                {
                    email = m.Email,
                    gender = (int)m.Gender,
                    id = m.Id,
                    name = m.Name,
                    typeCourse = m.TypeCourse,
                    study = m.Study,
                    image = m.Image,
                    phone = m.Phone,
                    studentSubCourses = m.StudentSubCourses.Select(item => new StudentSubCourses
                    {

                        id = item.Id,
                        studentId = item.StudentId,
                        subCourseId = item.SubCourseId,
                    }).ToList()
                })
                .ToListAsync();
        }



        public async Task<ReturnStudentDTO> GetByIdAsyncWithSubCourse(Guid id)
        {
            return await context.Students.Include(m => m.StudentSubCourses)
                .AsNoTracking()
                .Select(m => new ReturnStudentDTO
                {
                    email = m.Email,
                    gender = (int)m.Gender,
                    id = m.Id,
                    name = m.Name,
                    typeCourse = m.TypeCourse,
                    study = m.Study,
                    image = m.Image,
                    phone = m.Phone,
                    studentSubCourses = m.StudentSubCourses.Select(item => new StudentSubCourses
                    {

                        id = item.Id,
                        studentId = item.StudentId,
                        subCourseId = item.SubCourseId,
                    }).ToList()
                })
                .FirstOrDefaultAsync(m => m.id == id);
        }
    }
}
