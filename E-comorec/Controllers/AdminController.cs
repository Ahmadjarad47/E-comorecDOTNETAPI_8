using E_comorec.API.Helper;
using E_ommorec.core.DTO;
using E_ommorec.core.InterFace;
using E_ommorec.core.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_comorec.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize(Roles = "SupAdmin")]
    public class AdminController : ControllerBase
    {
        private readonly IUnitOfWork work;
        public AdminController(IUnitOfWork work)
        {
            this.work = work;
        }
        [HttpPost("change-user-role")]
        public async Task<ActionResult> change(ChangeRoleFromAdmin changeRole)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    bool result = await work.ControllingUsers.ChangeRoleAsync(changeRole);
                    return result ? Ok(new BaseResponse(200, result.ToString())) : BadRequest(new BaseResponse(400, "something went wrong"));
                }
            }
            catch (Exception ex)
            {

                return BadRequest(new BaseResponse(400, ex.Message));
            }
            return BadRequest(new BaseResponse(400, "something went wrong"));

        }
        [HttpGet("Get-All-Users")]
        public async Task<IActionResult> get()
         => Ok(await work.ControllingUsers.GetAllAsync());
        [HttpGet("Get-User-By-Id")]
        public async Task<IActionResult> getbyid(string id)
        => Ok(await work.ControllingUsers.GetUserByIdAsync(id));
        [HttpDelete("Delete-User")]
        public async Task<ActionResult> Delete(string id)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    bool res = await work.ControllingUsers.DeleteUserAsync(id);
                    return Ok(new BaseResponse(200, res.ToString()));
                }

            }
            catch (Exception ex)
            {

                return BadRequest(new BaseResponse(400, ex.Message));
            }
            return BadRequest(new BaseResponse(400));
        }

    }
}
