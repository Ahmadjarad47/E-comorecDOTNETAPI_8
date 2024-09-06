using AutoMapper;
using E_commorec.core.DTO;
using E_commorec.core.InterFace;
using E_comorec.API.Controllers.Admin;
using E_comorec.API.Helper;
using Microsoft.AspNetCore.Mvc;

namespace Controllers.Admin
{

    //[Authorize(Roles = "SupAdmin")]
    public class AdminController : BaseAdminController
    {
        public AdminController(IUnitOfWork service, IMapper mapper) : base(service, mapper)
        {
        }

        [HttpPost("change-user-role")]
        public async Task<ActionResult> change(ChangeRoleFromAdmin changeRole)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    bool result = await _service.ControllingUsers.ChangeRoleAsync(changeRole);
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
         => Ok(await _service.ControllingUsers.GetAllAsync());
        [HttpGet("Get-User-By-Id")]
        public async Task<IActionResult> getbyid(string id)
        => Ok(await _service.ControllingUsers.GetUserByIdAsync(id));
        [HttpDelete("Delete-User")]
        public async Task<ActionResult> Delete(string id)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    bool res = await _service.ControllingUsers.DeleteUserAsync(id);
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
