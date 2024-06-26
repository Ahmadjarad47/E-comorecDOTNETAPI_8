using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_ommorec.core.DTO
{
    public record UserRegisterDTO([Required] string UserName, [EmailAddress] string Email, [Required] string password);

}
