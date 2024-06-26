using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_ommorec.core.DTO
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
