using AutoMapper;
using E_commorec.core.DTO.Course;
using E_commorec.core.Entity;
using E_commorec.core.InterFace;
using E_comorec.API.Controllers.Admin;
using E_comorec.API.Helper;
using Microsoft.AspNetCore.Mvc;

namespace Controllers.Admin
{
    public class CoursesController : BaseAdminController
    {
        public CoursesController(IUnitOfWork service, IMapper mapper) : base(service, mapper)
        {
        }
        [HttpGet("get-AllAsync")]
        public async Task<IActionResult> get()
            => Ok(await _service.Course.GetAllAsync());

        [HttpGet("get-by-id/{id}")]
        public async Task<IActionResult> getid(int id)
       => Ok(await _service.Course.GetByIdAsync(id));

        [HttpPost("Create-Course")]
        public async Task<IActionResult> add([FromBody] CreateCourseDTO create)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _service.Course.AddAsync(mapper.Map<Course>(create));
                    return Ok(new BaseResponse(200, "Item Has been Added"));
                }
                return BadRequest(new BaseResponse(400, "bad request"));
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpPut("Update-Course")]
        public async Task<IActionResult> update([FromBody] UpdateCourseDTO update)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _service.Course.AddAsync(mapper.Map<Course>(update));
                    return Ok(new BaseResponse(200, "Item Has been Updated"));
                }
                return BadRequest(new BaseResponse(400, "bad request"));
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("delete-course/{id}")]
        public async Task Delete(int id)
        => await _service.Course.DeleteAsync(id);
    }
}
