using System.ComponentModel.DataAnnotations;

namespace E_commorec.core.Entity
{
    public class Course
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }




    }
}
