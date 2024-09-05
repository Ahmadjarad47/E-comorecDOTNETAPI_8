using AutoMapper;
using E_commorec.core.DTO.Student;
using E_commorec.core.DTO.Teacher;
using E_commorec.core.Entity;
using E_commorec.core.InterFace;
using E_commorec.core.Shared;
using E_comorec.API.Helper;
using Microsoft.AspNetCore.Mvc;

namespace E_comorec.API.Controllers.Users
{
    public class TeachersController : BaseController
    {
        public TeachersController(IUnitOfWork service, IMapper mapper) : base(service, mapper)
        {
        }
        [HttpGet("Get-AllAsync")]
        public async Task<ActionResult> get()
        => Ok(await _service.Teacher.GetAllAsync());


        [HttpGet("get-by-id")]
        public async Task<ActionResult> get(Guid id)
        => Ok(await _service.Teacher.GetByGUIDAsync(id));


        [HttpPost("Add-Teacher")]
        public async Task<ActionResult> add([FromBody] TeacherDTO teacher)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var result = mapper.Map<Teacher>(teacher);
                    Random random = new Random();
                    if (result.Gender == Gender.Male)
                    {
                        result.Image = $"/Images/Male/{random.Next(1, 18)}.png";
                    }
                    else
                    {
                        result.Image = $"/Images/Female/{random.Next(1, 15)}.png";
                    }
                    await _service.Teacher.AddAsync(result);
                    return Ok(new BaseResponse(200, "Item Has been Added"));
                }
                return BadRequest(new BaseResponse(400, "bad request"));
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }


        [HttpPut("Update-Teacher")]
        public async Task<ActionResult> Update([FromBody] UpdateTeacherDTO teacher)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _service.Teacher.UpdateAsync(mapper.Map<Teacher>(teacher));
                    return Ok(new BaseResponse(200, "Item Has been Updated"));
                }
                return BadRequest(new BaseResponse(400, "bad request"));
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("Delete-Teacher")]
        public async Task delelte(Guid id)
       => await _service.Teacher.DeleteByGuidAsync(id);
    }
}
