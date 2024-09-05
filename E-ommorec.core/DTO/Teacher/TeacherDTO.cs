using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commorec.core.DTO.Teacher
{
    public record TeacherDTO
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Position { get; set; }


        [Required]
        public string LevelOfStudy { get; set; }


        [Required]
        [Phone]
        public string Phone { get; set; }


        [Required]
        [EmailAddress]
        public string Email { get; set; }
        public int Gender { get; set; }

    }
    public record UpdateTeacherDTO : TeacherDTO
    {
        public Guid Id { get; set; }
    }
}
