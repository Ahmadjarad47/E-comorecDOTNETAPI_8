using E_ommorec.core.DTO;
using E_ommorec.core.Entity;
using E_ommorec.core.InterFace;
using E_ommorec.core.InterFace.User;
using E_ommorec.core.Services;
using E_ommorec.core.Shared;
using Microsoft.AspNetCore.Identity;
using System.Security.Cryptography;
namespace E_commorec.infrastructuer.Repositries.Users;

/// <summary>
/// Repository for handling user registration, login, and account management.
/// </summary>
public class RegisterRepositries : IUsers
{
    private readonly UserManager<AppUsers> _user;
    private readonly IGenerateTokenService generateTokenService;
    private readonly IEmailService emailService;

    /// <summary>
    /// Constructor to initialize dependencies.
    /// </summary>
    /// <param name="user">UserManager instance for AppUsers.</param>
    /// <param name="generate">Token generation service.</param>
    /// <param name="emailService">Email service.</param>
    public RegisterRepositries(UserManager<AppUsers> user, IGenerateTokenService generate, IEmailService emailService)
    {
        _user = user;
        this.generateTokenService = generate;
        this.emailService = emailService;
    }

    /// <summary>
    /// Registers a new user asynchronously.
    /// </summary>
    /// <param name="user">User registration DTO.</param>
    /// <returns>Result code indicating success or failure.</returns>
    public async Task<int> RegisterAsync(UserRegisterDTO user)
    {
        // Check if the model is null
        if (user == null)
        {
            return -1;
        }

        // Check if the username or email already exists
        if (await _user.FindByEmailAsync(user.Email) is not null)
        {
            return -2;
        }

        if (await _user.FindByNameAsync(user.UserName) is not null)
        {
            return -3;
        }

        // Initialize user and register
        AppUsers app = new AppUsers()
        {
            UserName = user.UserName,
            Email = user.Email,
            EmailConfirmed = false,
            LockoutEnabled = true,
            Role = Roles.User
        };

        // Generate activation code
        string token = await _user.GenerateEmailConfirmationTokenAsync(app);


        // Send activation email
        sendEmail(token, user.Email, "Activate your account", "Confirm Email", "ActiveAccount");

        // Create user
        IdentityResult res = await _user.CreateAsync(app, user.password);
        await _user.AddToRoleAsync(app, Roles.User);

        if (res.Succeeded == false)
        {
            return -4;
        }


        return 1;
    }

    /// <summary>
    /// Logs in a user asynchronously.
    /// </summary>
    /// <param name="user">User login DTO.</param>
    /// <returns>Result code indicating success or failure.</returns>
    public async Task<string> LoginAsync(UserLoginDTO user)
    {
        // Check if the model is null
        if (user == null)
        {
            return "-1";
        }

        // Find user by email or username
        AppUsers finduser = await _user.FindByEmailAsync(user.EmailOrUserName);
        if (finduser is null)
        {
            finduser = await _user.FindByNameAsync(user.EmailOrUserName);
            if (finduser is null)
            {
                return "-5"; // User not registered or found
            }
        }

        // Check if email is confirmed
        if (finduser.EmailConfirmed == false)
        {
            // Generate activation code
            var token = await _user.GenerateEmailConfirmationTokenAsync(finduser);


            // Send confirmation email
            sendEmail(token, finduser.Email, "Activate your account", "Confirm Email", "ActiveAccount");
            await _user.UpdateAsync(finduser);

            return "-7";
        }

        // Check password
        bool res = await _user.CheckPasswordAsync(finduser, user.password);
        if (!res) { return "-6"; } // Password not correct

        //Generate token
        var accessToken = await generateTokenService.GetAndCreateToken(finduser);

        return accessToken;
    }

    /// <summary>
    /// Checks if a user exists asynchronously.
    /// </summary>
    /// <param name="usernameOrEmail">Username or email to check.</param>
    /// <returns>True if user exists, otherwise false.</returns>
    public async Task<bool> checkUserAsync(string usernameOrEmail)
    {
        AppUsers finduser = await _user.FindByEmailAsync(usernameOrEmail);

        if (finduser is null)
        {
            finduser = await _user.FindByNameAsync(usernameOrEmail);

            if (finduser is null)
            {
                return false; // User not registered or found
            }
        }
        return true;
    }

    /// <summary>
    /// Initiates the first step to delete a user account asynchronously.
    /// </summary>
    /// <param name="user">User login DTO.</param>
    /// <returns>Status message.</returns>
    public async Task<string> firstStepToDeleteAccountAsync(UserLoginDTO user)
    {
        AppUsers finduser = await _user.FindByEmailAsync(user.EmailOrUserName);

        if (finduser is null)
        {
            finduser = await _user.FindByNameAsync(user.EmailOrUserName);

            if (finduser is null)
            {
                return "User not Found"; // User not registered or found
            }
        }

        // Check password
        bool res = await _user.CheckPasswordAsync(finduser, user.password);
        if (!res) { return "The password is incorrect"; }

        finduser.ConfiermDeleteAccount = true;
        await _user.UpdateAsync(finduser);
        return "Done!";
    }

    /// <summary>
    /// Confirms the deletion of a user account asynchronously.
    /// </summary>
    /// <param name="usernameOrEmail">Username or email to delete.</param>
    /// <returns>True if deletion is successful, otherwise false.</returns>
    public async Task<bool> ConfiermDeleteAccountAsync(string usernameOrEmail)
    {
        AppUsers finduser = await _user.FindByEmailAsync(usernameOrEmail);

        if (finduser is null)
        {
            finduser = await _user.FindByNameAsync(usernameOrEmail);

            if (finduser is null)
            {
                return false; // User not registered or found
            }
        }

        if (!finduser.ConfiermDeleteAccount)
        {
            return false;
        }

        await _user.DeleteAsync(finduser);
        return true;
    }

    /// <summary>
    /// Sends an email.
    /// </summary>
    /// <param name="code">Verification code.</param>
    /// <param name="email">Recipient email.</param>
    /// <param name="message">Email message.</param>
    /// <param name="type">Email type.</param>
    /// <param name="component">Email component.</param>
    public void sendEmail(string code, string email, string message, string type, string component)
    {
        EmailModel emailModel = new EmailModel(email, type, "ahmad222jarad@gmail.com", EmailBody.EmailStringBody(email, code, message, component));
        emailService.SendEmail(emailModel);
    }

    /// <summary>
    /// Sends a verification email for password reset asynchronously.
    /// </summary>
    /// <param name="Email">User email.</param>
    /// <returns>Result code indicating success or failure.</returns>
    public async Task<int> ForgetPassword(ForgetPasswordDTO Email)
    {
        AppUsers user = await _user.FindByEmailAsync(Email.Email);
        if (user == null)
        {
            return -5;
        }

        string Responsetoken = Email.codeSecuerty.Replace("%2F", "/").Replace("%2B", "+").Replace("%3D", "=");

        var result = await _user.ResetPasswordAsync(user, Responsetoken, Email.password);


        if (result.Succeeded is false)
        {
            // Generate activation code
            string token = await _user.GeneratePasswordResetTokenAsync(user);

            // Send reset email

            sendEmail(token, user.Email, "Reset password", "Reset your password", "Reset-password");

        }

        await _user.UpdateAsync(user);


        return 1;
    }




    public async Task<bool> SendEmailForgetPassword(string email)
    {
        AppUsers user = await _user.FindByEmailAsync(email);
        if (user == null)
        {
            return false;
        }
        // Generate activation code
        var token = await _user.GeneratePasswordResetTokenAsync(user);



        await _user.UpdateAsync(user);

        sendEmail(token, user.Email, "Reset password", "Reset your password", "Reset-password");
        return true;
    }
    /// <summary>
    /// Activates email verification asynchronously.
    /// </summary>
    /// <param name="Email">Forget password DTO.</param>
    /// <returns>Result code indicating success or failure.</returns>
    public async Task<int> ActiveEmail(ActiveEmailDTO Email)
    {
        AppUsers user = await _user.FindByEmailAsync(Email.Email);
        if (user == null)
        {
            return -5;
        }

        string Responsetoken = Email.codeSecuerty.Replace("%2F", "/").Replace("%2B", "+").Replace("%3D", "=");

        IdentityResult result = await _user.ConfirmEmailAsync(user, Responsetoken);
        // Check if the code is expired or invalid
        if (result.Succeeded is false)
        {
            // Generate activation code
            var token = await _user.GenerateEmailConfirmationTokenAsync(user);

            // Send reset email

            sendEmail(token, user.Email, "Activate your account", "Confirm Email", "ActiveAccount");

            return -8;
        }

        await _user.UpdateAsync(user);
        return 1;
    }
}
