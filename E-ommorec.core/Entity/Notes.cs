using System.ComponentModel.DataAnnotations;

namespace E_commorec.core.Entity
{
    public class Notes
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Status { get; set; }

        [Required]
        [EmailAddress]
        public string EmailForWho { get; set; }

        public DateTime WhenHeRead { get; set; }
        public bool ReadOrNot { get; set; } = false;

    }
}
