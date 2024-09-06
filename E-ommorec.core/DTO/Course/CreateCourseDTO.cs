using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_commorec.core.DTO.Course
{
    public record CreateCourseDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
    public record UpdateCourseDTO : CreateCourseDTO
    {
        public int Id { get; set; }
    }
    public record CreateSubCourse
    {


        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [Required]
        public int TotalHour { get; set; }
        [Required]
        public int Hourscompleted { get; set; }
        [Required]
        public int TimeOfLectuer { get; set; }
        [Required]
        public string Day { get; set; }
        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }
        [Required]
        public string TimeHouerFromTo { get; set; }


        public IFormFile Image { get; set; }

        public Guid TeacherId { get; set; }
        public int CourseId { get; set; }

    }
    public record UpdateProprties : CreateSubCourse
    {
        public int Id { get; set; }
    }
    public record AddORStudentCourse
    {
        public int Id { get; set; }
        public Guid[] StudentId { get; set; }
    }
    public class ReturnSubCourse
    {

        public int Id { get; set; }


        public string Name { get; set; }


        public int TotalHour { get; set; }

        public int Hourscompleted { get; set; }

        public int TimeOfLectuer { get; set; }

        public string Day { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }

        public string TimeHouerFromTo { get; set; }

        public string TeacherName { get; set; }
        public Guid TeacherId { get; set; }

        public string Image { get; set; }
        public string CourseName { get; set; }

        public virtual List<StudentSub> studentSubs { get; set; }
    }
    public class StudentSub
    {
        public Guid Id { get; set; }
        public string Name { get; set; }//NameofStudent
    }
}
