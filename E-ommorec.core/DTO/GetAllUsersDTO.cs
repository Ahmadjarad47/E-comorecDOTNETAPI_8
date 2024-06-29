using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commorec.core.DTO
{
    public class GetAllUsersDTO
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string EmailConfierm { get; set; }
        public string id { get; set; }
        public string Role { get; set; }
    }
}
