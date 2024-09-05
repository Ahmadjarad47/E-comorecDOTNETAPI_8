using AutoMapper;
using E_commorec.core.DTO.Course;
using E_commorec.core.Entity;

namespace E_comorec.API.Mapper
{
    public class CourseMapper : Profile
    {
        public CourseMapper()
        {
            CreateMap<Course, CreateCourseDTO>().ReverseMap();
            CreateMap<Course, UpdateCourseDTO>().ReverseMap();
            CreateMap<SubCourse, UpdateProprties>()
                //  ().ForMember(m => m.CourseId,
                //x => x.MapFrom(m => m.Course.Id))
                //  .ForMember(m => m.TeacherId,
                //  x => x.MapFrom(x => x.Teacher.Id))
                .ReverseMap();
        }
    }
}
