using E_commorec.core.DTO;
using E_commorec.core.Entity;
using E_commorec.core.InterFace.User;
using E_commorec.core.Shared;
using E_commorec.infrastructuer.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace E_commorec.infrastructuer.Repositries.Users
{
    public class AdminControllingUsers : IAdminControllingUsers
    {
        private readonly AppDbContext context;
        private readonly UserManager<AppUsers> roleManager;
        public AdminControllingUsers(AppDbContext context, UserManager<AppUsers> roleManager)
        {
            this.context = context;
            this.roleManager = roleManager;
        }

        public async Task<bool> ChangeRoleAsync(ChangeRoleFromAdmin EmailOrUserName)
        {
            AppUsers user = await context.AppUsers.Where(m => m.Email == EmailOrUserName.EmailOrUserName
             || m.UserName == EmailOrUserName.EmailOrUserName).FirstOrDefaultAsync();

            if (user == null) { return false; }


            string[] roles = Roles.roles;
            for (int i = 0; i < 3; i++)
            {
                string role = roles[i];
                IdentityResult result = await roleManager.RemoveFromRoleAsync(user, role);
                if (result.Succeeded is true)
                {
                    break;
                }
            }

            IdentityResult res = await roleManager.AddToRoleAsync(user, EmailOrUserName.Role);
            user.Role = EmailOrUserName.Role;
            await roleManager.UpdateAsync(user);
            if (res.Succeeded is false)
            {
                return false;
            }

            return true;
        }

        public async Task<bool> DeleteUserAsync(string id)
        {
            AppUsers user = await roleManager.FindByIdAsync(id);
            IdentityResult deleteUser = await roleManager.DeleteAsync(user);
            if (deleteUser.Succeeded is false)
            {
                return false;
            }
            return true;
        }

        public async Task<IReadOnlyList<GetAllUsersDTO>> GetAllAsync()
        {
            var users = context.AppUsers.Select(m => new GetAllUsersDTO
            {
                UserName = m.UserName,
                Email = m.Email,
                EmailConfierm = m.EmailConfirmed.ToString(),
                id = m.Id
                ,
                Role = m.Role

            }).AsNoTracking();
            return await users.ToListAsync();
        }

        public async Task<GetAllUsersDTO> GetUserByIdAsync(string id)
        {
            var user = await context.AppUsers.Select(x => new GetAllUsersDTO
            {
                Email = x.Email,
                EmailConfierm = x.EmailConfirmed.ToString(),
                id = id
               ,
                Role = x.Role
              ,
                UserName = x.UserName
            }).AsNoTracking().FirstOrDefaultAsync();
            return user;
        }
    }

}
