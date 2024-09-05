using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_commorec.core.Entity
{

    public class Certificate
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public Degree State { get; set; } = Degree.pending;

        public Guid StudentId { get; set; }

        [ForeignKey(nameof(StudentId))]
        public virtual Student Student { get; set; }

        public int SubCourseId { get; set; }

        [ForeignKey(nameof(SubCourseId))]
        public virtual SubCourse SubCourse { get; set; }
    }

    public enum Degree
    {
        FirstClassHonours,
        UpperSecondClassHonours,
        LowerSecondClassHonours,
        ThirdClassHonours,
        Pass,
        Fail,
        pending
    }


}
