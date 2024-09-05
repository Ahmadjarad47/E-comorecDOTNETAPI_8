using E_commorec.core.DTO.Course;
using E_commorec.core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commorec.core.InterFace
{
    public interface ISubCourse : IGenericRepositry<SubCourse>
    {
        Task<IReadOnlyList<ReturnSubCourse>> GetAllAsync();
        Task<ReturnSubCourse> GetByIdAsync(int id);
        Task<bool> AddAsync(CreateSubCourse createSubCourse);
        Task<bool> UpdateStudentAsync(AddORStudentCourse sameCourse);
        Task<bool> UpdateAsync(UpdateProprties sameCourse);
        Task<bool> DeleteStudentAsync(AddORStudentCourse course);
    }
}
