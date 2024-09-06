using System.ComponentModel.DataAnnotations;

namespace E_commorec.core.DTO
{
    public record ActiveEmailDTO
    ([Required][EmailAddress] string Email, [Required] string codeSecuerty);
}
