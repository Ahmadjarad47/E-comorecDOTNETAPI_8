using E_commorec.core.DTO;
using E_commorec.core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commorec.core.InterFace.User
{
    public interface IAdminControllingUsers
    {
        Task<bool> ChangeRoleAsync(ChangeRoleFromAdmin EmailOrUserName);
        Task<IReadOnlyList<GetAllUsersDTO>> GetAllAsync();
        Task<GetAllUsersDTO> GetUserByIdAsync(string id);
        Task<bool> DeleteUserAsync(string id);
    }
}
