using System.ComponentModel.DataAnnotations;

namespace E_commorec.core.DTO
{
    public class ChangeRoleFromAdmin
    {

        [Required]
        public string EmailOrUserName { get; set; }
        [Required]
        [MinLength(3)]
        public string Role { get; set; }

    }
}
