using E_comorec.API.Helper;
using E_commorec.core.DTO;
using E_commorec.core.InterFace;
using E_commorec.core.InterFace.User;
using E_commorec.core.Services;
using E_commorec.core.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using E_comorec.API.Controllers;
using AutoMapper;

namespace Controllers.Users;


public class AccountController : BaseController
{
    public AccountController(IUnitOfWork service, IMapper mapper) : base(service, mapper)
    {
    }

    /// <summary>
    /// Constructor to initialize dependencies.
    /// </summary>
    /// <param name="service">Unit of Work service.</param>



    /// <summary>
    /// Registers a new user.
    /// </summary>
    /// <param name="userRegisterDTO">User registration data.</param>
    /// <returns>Action result indicating success or failure.</returns>
    [HttpPost("Register")]
    public async Task<ActionResult> Registeration(UserRegisterDTO userRegisterDTO)
    {
        int res = 10;
        try
        {
            if (ModelState.IsValid)
            {
                res = await _service.users.RegisterAsync(userRegisterDTO);
                if (Math.Sign(res) == 1)
                {
                    return Ok(new BaseResponse(200, "user register success"));
                }
            }
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
        return BadRequest(new BaseResponse(res));
    }
















    /// <summary>
    /// Logs in a user.
    /// </summary>
    /// <param name="userLogin">User login data.</param>
    /// <returns>Action result indicating success or failure.</returns>
    [HttpPost("Login")]
    //[Authorize(Roles = "User")]
    public async Task<ActionResult> Logins(UserLoginDTO userLogin)
    {

        try
        {
            if (ModelState.IsValid)
            {
                string result = await _service.users.LoginAsync(userLogin);
                if (result.Substring(0, 1) is "-")
                {
                    return BadRequest(new BaseResponse(int.Parse(result)));
                }
                Response.Cookies.Append("token", result, new CookieOptions
                {
                    HttpOnly = true,
                    Secure = true,
                    SameSite = SameSiteMode.Strict,
                    IsEssential = true,
                    Domain = "https://localhost/4200",
                    Expires = DateTime.Now.AddHours(30),

                });
                return Ok(new BaseResponse(200, "login success"));
            }
        }
        catch (Exception ex)
        {
            return BadRequest(new BaseResponse(400, ex.Message));
        }
        return BadRequest(new BaseResponse(400));
    }


    [HttpPost("Logout")]
    public Task logout()
    {

        Response.Cookies.Append("token", " ", new CookieOptions
        {
            HttpOnly = true,
            Secure = true,
            SameSite = SameSiteMode.Strict,
            IsEssential = true,
            Domain = "https://localhost/4200",
            Expires = DateTime.Now.AddSeconds(-1),
        });
        return Task.CompletedTask;

    }




    [HttpGet("send-email-forget-password")]
    public async Task<ActionResult> SendEmailForgetPassword([Required][EmailAddress] string email)
    {
        try
        {
            if (ModelState.IsValid)
            {
                bool result = await _service.users.SendEmailForgetPassword(email);
                return result ? Ok(new BaseResponse(200, result.ToString()))
                    : BadRequest(new BaseResponse(400, result.ToString()));
            }
        }
        catch (Exception ex)
        {

            return BadRequest(new BaseResponse(400, ex.Message));
        }
        return BadRequest(new BaseResponse(400));
    }




    /// <summary>
    /// Sends a password reset email.
    /// </summary>
    /// <param name="Email">User email address.</param>
    /// <returns>Action result indicating success or failure.</returns>
    [HttpPost("Reset-Password")]
    public async Task<ActionResult> ForgetPasswordResetIt([FromBody] ForgetPasswordDTO forget)
    {
        int result = 10;
        try
        {
            if (ModelState.IsValid)
            {
                result = await _service.users.ForgetPassword(forget);
                if (Math.Sign(result) == 1)
                {
                    return Ok(new BaseResponse(200, "Password change success"));
                }
            }
        }
        catch (Exception ex)
        {
            return BadRequest(new BaseResponse(400, ex.Message));
        }
        return BadRequest(new BaseResponse(result));
    }









    /// <
    /// 
    /// 
    /// 
    /// 
    /// 
    /// 
    /// 
    /// >
    /// Activates a user account.
    /// </summary>
    /// <param name="Email">User email and security code.</param>
    /// <returns>Action result indicating success or failure.</returns>
    [HttpPost("Active-Account")]
    public async Task<ActionResult> ActiveAccounting(ActiveEmailDTO Email)
    {
        int result = 0;
        try
        {
            if (ModelState.IsValid)
            {
                result = await _service.users.ActiveEmail(Email);
                if (Math.Sign(result) == 1)
                {
                    return Ok(new BaseResponse(200, "Your email is active now!"));
                }
            }
        }
        catch (Exception ex)
        {
            return BadRequest(new BaseResponse(400, ex.Message));
        }
        return BadRequest(new BaseResponse(result));
    }















    /// <summary>
    /// Initiates the deletion of a user account.
    /// </summary>
    /// <param name="userLogin">User login data.</param>
    /// <returns>Action result indicating success or failure.</returns>
    [HttpDelete("Delete-Account")]
    public async Task<ActionResult> DeleteAccount(UserLoginDTO userLogin)
    {
        string result = "10";
        try
        {
            if (ModelState.IsValid)
            {
                result = await _service.users.firstStepToDeleteAccountAsync(userLogin);
                if (result == "Done!")
                {
                    return Ok(new BaseResponse(200, result));
                }
            }
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
        return BadRequest(new BaseResponse(400));
    }










    /// <summary>
    /// Confirms the deletion of a user account.
    /// </summary>
    /// <param name="EmailOrUserName">User email or username.</param>
    /// <returns>Action result indicating success or failure.</returns>
    [HttpDelete("Confierm-Delete-Account")]
    public async Task<ActionResult> ConfiermDeleteAccountAsync(string EmailOrUserName)
    {
        bool result = false;
        try
        {
            if (ModelState.IsValid)
            {
                result = await _service.users.ConfiermDeleteAccountAsync(EmailOrUserName);
                if (result)
                {
                    return Ok(new BaseResponse(200, "Done!"));
                }
            }
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
        return BadRequest(new BaseResponse(400, "Something went wrong.. check if you are logged in"));
    }
}
