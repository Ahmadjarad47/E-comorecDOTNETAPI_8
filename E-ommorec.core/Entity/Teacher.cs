using E_commorec.core.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commorec.core.Entity
{
    public class Teacher
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();


        [Required]
        public DateTime FirstTimeRegister { get; set; }


        [Required]
        public DateTime TimeToResign { get; set; }

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


        public Gender Gender { get; set; }
        public string Image { get; set; }
    }
}
