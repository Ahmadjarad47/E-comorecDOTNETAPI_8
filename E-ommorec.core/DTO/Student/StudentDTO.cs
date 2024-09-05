using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commorec.core.DTO.Student
{
    public record StudentDTO
    {
        public string Name { get; set; }

        [Required]
        public string Study { get; set; }

        [Required]
        [Phone]
        public string Phone { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }
        public int Gender { get; set; }
        public string[] TypeCourse { get; set; }
    }
    public record UpdateStudentDTO : StudentDTO
    {
        public Guid Id { get; set; }
    }
    public class ReturnStudentDTO
    {
        public Guid id { get; set; }
        public string name { get; set; }
        public DateTime firstTimeRegister { get; set; }
        public string study { get; set; }
        public string phone { get; set; }
        public string email { get; set; }
        public int gender { get; set; }
        public string image { get; set; }
        public string[] typeCourse { get; set; }
        public List<StudentSubCourses> studentSubCourses { get; set; }
    }

    public record StudentSubCourses
    {
        public int id { get; set; }
        public Guid studentId { get; set; }

        public int subCourseId { get; set; }
    }
}
