using E_commorec.core.DTO.Student;
using E_commorec.core.Entity;

namespace E_commorec.core.InterFace
{
    public interface IStudent : IGenericRepositry<Student>
    {
        Task<IReadOnlyList<ReturnStudentDTO>> GetAllAsyncWithSubCourse();
        Task<ReturnStudentDTO> GetByIdAsyncWithSubCourse(Guid id);
    }
}
