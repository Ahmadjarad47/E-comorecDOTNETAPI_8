﻿using E_commorec.core.DTO;

namespace E_commorec.core.InterFace.User
{
    public interface IUsers
    {
        Task<int> RegisterAsync(UserRegisterDTO user);
        Task<string> LoginAsync(UserLoginDTO user);
        Task<bool> checkUserAsync(string usernameOrEmail);
        Task<string> firstStepToDeleteAccountAsync(UserLoginDTO user);
        Task<bool> ConfiermDeleteAccountAsync(string usernameOrEmail);
        Task<int> ForgetPassword(ForgetPasswordDTO Email);
        Task<bool> SendEmailForgetPassword(string email);
        Task<int> ActiveEmail(ActiveEmailDTO Email);
    }
}
