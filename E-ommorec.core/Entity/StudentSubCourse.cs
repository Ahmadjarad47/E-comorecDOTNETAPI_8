namespace E_commorec.core.Entity
{
    public class StudentSubCourse
    {
        public int Id { get; set; }

        public Guid StudentId { get; set; }
        public virtual Student Student { get; set; }

        public int SubCourseId { get; set; }
        public virtual SubCourse SubCourse { get; set; }
    }

}
