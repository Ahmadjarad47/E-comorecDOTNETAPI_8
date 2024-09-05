using AutoMapper;
using E_commorec.core.DTO.Teacher;
using E_commorec.core.Entity;

namespace E_comorec.API.Mapper
{
    public class TeacherMapper : Profile
    {
        public TeacherMapper()
        {
            CreateMap<Teacher, TeacherDTO>().ReverseMap();
            CreateMap<Teacher, UpdateTeacherDTO>().ReverseMap();
        }
    }
}
