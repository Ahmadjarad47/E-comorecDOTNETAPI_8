using E_commorec.core.DTO.Course;
using E_commorec.core.Entity;

namespace E_commorec.core.InterFace
{
    public interface ISubCourse : IGenericRepositry<SubCourse>
    {
        Task<IReadOnlyList<ReturnSubCourse>> GetAllAsync();
        Task<IReadOnlyList<ReturnSubCourse>> GetCoursesForStudent(string email);
        Task<ReturnSubCourse> GetCourseForStudent(string email, int id);

        Task<ReturnSubCourse> GetByIdAsync(int id);
        Task<bool> AddAsync(CreateSubCourse createSubCourse);
        Task<bool> UpdateStudentAsync(AddORStudentCourse sameCourse);
        Task<bool> UpdateAsync(UpdateProprties sameCourse);
        Task<bool> DeleteStudentAsync(AddORStudentCourse course);
    }
}
