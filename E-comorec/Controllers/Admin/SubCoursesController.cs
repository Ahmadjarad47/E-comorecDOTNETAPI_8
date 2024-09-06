using AutoMapper;
using E_commorec.core.DTO.Course;
using E_commorec.core.InterFace;
using E_comorec.API.Controllers.Admin;
using E_comorec.API.Helper;
using Microsoft.AspNetCore.Mvc;

namespace Controllers.Admin
{

    public class SubCoursesController : BaseAdminController
    {
        public SubCoursesController(IUnitOfWork service, IMapper mapper) : base(service, mapper)
        {
        }



        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet("Get-AllAsync")]
        public async Task<ActionResult<IReadOnlyList<ReturnSubCourse>>> get()
         => Ok(await _service.SubCourse.GetAllAsync());





        /// <summary>
        /// 
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet("Get-By-Id/{Id}")]
        public async Task<IActionResult> get(int Id)
       => Ok(await _service.SubCourse.GetByIdAsync(Id));





        /// <summary>
        /// 
        /// </summary>
        /// <param name="createSub"></param>
        /// <returns></returns>
        [HttpPost("Add-SubCourse")]
        public async Task<IActionResult> add([FromQuery] CreateSubCourse createSub)
        {
            if (ModelState.IsValid)
            {
                await _service.SubCourse.AddAsync(createSub);
                return Ok(new BaseResponse(200, "item added"));
            }
            return BadRequest();
        }






        /// <summary>
        /// 
        /// </summary>
        /// <param name="createSub"></param>
        /// <returns></returns>
        [HttpPut("Update-Student-SubCourse")]
        public async Task<ActionResult> update([FromBody] AddORStudentCourse createSub)
        {
            if (ModelState.IsValid)
            {
                await _service.SubCourse.UpdateStudentAsync(createSub);
                return Ok(new BaseResponse(200, "item updated"));
            }
            return BadRequest();
        }


        [HttpPut("Update-proprties-SubCourse")]
        public async Task<ActionResult> updateprop([FromQuery] UpdateProprties createSub)
        {
            if (ModelState.IsValid)
            {
                var result = await _service.SubCourse.UpdateAsync(createSub);
                return result ? Ok(new BaseResponse(200, "item updated"))
                             : BadRequest(new BaseResponse(400));
            }
            return BadRequest();
        }

        [HttpDelete("Delete-Student-SubCourse")]
        public async Task<ActionResult> deleteST(AddORStudentCourse course)
        {
            await _service.SubCourse.DeleteStudentAsync(course);
            return Ok(new BaseResponse(200, "item has been deleted"));
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpDelete("Delete-SubCourse")]
        public async Task<ActionResult> delete(int Id)
        {
            await _service.SubCourse.DeleteAsync(Id);
            await _service.SubCourse.DeleteFromMemoryCache("ListSubCourse");
            return Ok(new BaseResponse(200, "Item Deleted"));
        }
    }
}
