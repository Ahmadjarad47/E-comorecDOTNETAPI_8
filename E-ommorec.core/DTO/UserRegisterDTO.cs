using System.ComponentModel.DataAnnotations;

namespace E_commorec.core.DTO
{
    public record UserRegisterDTO([Required] string UserName, [EmailAddress] string Email, [Required] string password, [Required] string type);

}
