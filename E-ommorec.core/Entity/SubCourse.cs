using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_commorec.core.Entity
{
    public class SubCourse
    {
        [Key]
        public int Id { get; set; }

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


        public string Image { get; set; }

        public Guid TeacherId { get; set; }
        [ForeignKey(nameof(TeacherId))]
        public virtual Teacher Teacher { get; set; }


        public int CourseId { get; set; }
        [ForeignKey(nameof(CourseId))]
        public virtual Course Course { get; set; }

        public virtual ICollection<StudentSubCourse> StudentSubCourses { get; set; }

    }
}
