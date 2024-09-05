using E_commorec.core.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commorec.core.Entity
{
    public class Student
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [Required]
        [MaxLength(35)]

        public string Name { get; set; }

        [Required]
        public DateTime FirstTimeRegister { get; set; } = DateTime.Now;

        [Required]
        public string Study { get; set; }


        [Required]
        [Phone]
        public string Phone { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public Gender Gender { get; set; }
        public string Image { get; set; }
        public string[] TypeCourse { get; set; }

        public virtual ICollection<StudentSubCourse> StudentSubCourses { get; set; }

    }
}
