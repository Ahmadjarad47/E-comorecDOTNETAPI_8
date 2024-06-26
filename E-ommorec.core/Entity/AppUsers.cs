using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_ommorec.core.Entity
{
    public class AppUsers : IdentityUser
    {
        public string RefreshToken { get; set; }
        public bool ConfiermDeleteAccount { get; set; } = false;
        public string Role { get; set; }
    }
}
