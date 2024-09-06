using System.ComponentModel.DataAnnotations;

namespace E_commorec.core.DTO
{
    public record ForgetPasswordDTO
    ([Required][EmailAddress] string Email, [Required] string password, string codeSecuerty);
}
