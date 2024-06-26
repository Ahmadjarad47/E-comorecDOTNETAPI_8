using E_ommorec.core.DTO;
using E_ommorec.core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_ommorec.core.InterFace.User
{
    public interface IAdminControllingUsers
    {
        Task<bool> ChangeRoleAsync(ChangeRoleFromAdmin EmailOrUserName);
        Task<IReadOnlyList<GetAllUsersDTO>> GetAllAsync();
        Task<GetAllUsersDTO> GetUserByIdAsync(string id);
        Task<bool> DeleteUserAsync(string id);
    }
}
