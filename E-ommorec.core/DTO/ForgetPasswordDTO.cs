using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commorec.core.DTO
{
    public record ForgetPasswordDTO
    ([Required][EmailAddress] string Email, [Required] string password, string codeSecuerty);
}
