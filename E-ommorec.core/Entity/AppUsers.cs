using Microsoft.AspNetCore.Identity;

namespace E_commorec.core.Entity
{
    public class AppUsers : IdentityUser
    {
        public DateTime FirstTimeAddStudent { get; set; } = DateTime.Now;

        public bool ConfiermDeleteAccount { get; set; } = false;
        public string Role { get; set; }




    }
}
