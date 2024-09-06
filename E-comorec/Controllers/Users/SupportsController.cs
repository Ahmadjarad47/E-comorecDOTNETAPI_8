using AutoMapper;
using Controllers.Users;
using E_commorec.core.DTO;
using E_commorec.core.Entity;
using E_commorec.core.InterFace;
using E_comorec.API.Helper;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace E_comorec.API.Controllers.Users
{
    public class SupportsController : BaseController
    {
        public SupportsController(IUnitOfWork service, IMapper mapper) : base(service, mapper)
        {
        }
        [HttpGet("Get-All-Async")]
        public async Task<IActionResult> get()
        => Ok(await _service.support.GetAllAsync());

        [HttpGet("Get-All-by-email-Async")]
        public async Task<IActionResult> getbyemail()
       => Ok(await _service.support.getSupportsByEmail(User.FindFirst(ClaimTypes.Email)?.Value));


        [HttpGet("Get-by-email-Async")]
        public async Task<IActionResult> getbyemailandId(int id)
       => Ok(await _service.support.getSupportByEmail(id, User.FindFirst(ClaimTypes.Email)?.Value));

        [HttpPost("Add-new-support")]
        public async Task<IActionResult> add(string message)
        {
            var Support = new Support()
            {
                TheMessage = message,
                WhoSendMessage = User.FindFirst(ClaimTypes.Email)?.Value
            };
            await _service.support.AddAsync(Support);
            return Ok(new BaseResponse(200, "item was send it"));
        }


        [HttpPost("Add-Response-support")]
        public async Task<IActionResult> add(SupportResponse support)
        {
            support.WhoReponsed = User.FindFirst(ClaimTypes.Email)?.Value;
            Ok(_service.support.CreateResponseFromAdmin(support));
            return Ok(new BaseResponse(200, "responsed"));
        }
        [HttpPut("update-message")]
        public async Task<IActionResult> updatemessage(string message, int id)
        => Ok(_service.support.UpdateTheMessage(id, User.FindFirst(ClaimTypes.Email)?.Value, message));

        [HttpPut("update-response")]
        public async Task<IActionResult> updateresponse(string message, int id)
       => Ok(_service.support.UpdateTheResponse(id, message));

        [HttpDelete("delete-support")]
        public async Task<IActionResult> delete(int id)
        {
            await _service.support.DeleteAsync(id);
            return Ok(new BaseResponse(200, "item was deleted"));
        }
    }
}