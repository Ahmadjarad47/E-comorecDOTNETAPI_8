using AutoMapper;
using Controllers.Users;
using E_commorec.core.InterFace;
using E_comorec.API.Helper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace E_comorec.API.Controllers.Users
{
    [Authorize("User")]
    public class NotesController : BaseController
    {
        public NotesController(IUnitOfWork service, IMapper mapper) : base(service, mapper)
        {
        }



        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet("get-All-Notes")]
        public async Task<ActionResult> get()
        {

            var email = User?.FindFirst(ClaimTypes.Email)?.Value;
            return !string.IsNullOrEmpty(email)
                ? Ok(await _service.note.GetAllAsync(email)) :
                BadRequest(new BaseResponse(404, "something went wrong please try again later"));


        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("get-by-id/{id}")]
        public async Task<ActionResult> get(int id)
        {
            var email = User?.FindFirst(ClaimTypes.Email)?.Value;
            return !string.IsNullOrEmpty(email)
               ? Ok(await _service.note.GetByIdAsync(email, id)) :
               BadRequest(new BaseResponse(404, "something went wrong please try again later"));

        }




        [HttpPut("read-the-note")]
        public async Task<ActionResult> update(int id, string email)
        {
            var getNote = await _service.note.GetByIdAsync(id);
            if (getNote.EmailForWho == email)
            {
                getNote.WhenHeRead = DateTime.Now;
                getNote.ReadOrNot = true;
                await _service.note.UpdateAsync(getNote);
                return Ok(value: getNote);
            }
            return BadRequest(new BaseResponse(400));
        }


    }
}
