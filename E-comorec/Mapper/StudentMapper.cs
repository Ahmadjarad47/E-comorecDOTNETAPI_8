using AutoMapper;
using E_commorec.core.DTO.Student;
using E_commorec.core.Entity;

namespace E_comorec.API.Mapper
{
    public class StudentMapper : Profile
    {
        public StudentMapper()
        {
            CreateMap<Student, StudentDTO>().ReverseMap();
            CreateMap<Student, UpdateStudentDTO>().ReverseMap();
        }
    }
}
