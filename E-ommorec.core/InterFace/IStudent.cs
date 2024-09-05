using E_commorec.core.DTO.Student;
using E_commorec.core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commorec.core.InterFace
{
    public interface IStudent : IGenericRepositry<Student>
    {
        Task<IReadOnlyList<ReturnStudentDTO>> GetAllAsyncWithSubCourse();
        Task<ReturnStudentDTO> GetByIdAsyncWithSubCourse(Guid id);
    }
}
