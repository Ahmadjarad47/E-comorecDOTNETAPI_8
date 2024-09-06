using E_commorec.core.DTO;

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
