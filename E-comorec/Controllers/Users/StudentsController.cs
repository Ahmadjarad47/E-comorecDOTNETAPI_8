using AutoMapper;
using E_commorec.core.DTO.Student;
using E_commorec.core.Entity;
using E_commorec.core.InterFace;
using E_commorec.core.Shared;
using E_comorec.API.Helper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_comorec.API.Controllers.Users
{

    public class StudentsController : BaseController
    {
        public StudentsController(IUnitOfWork service, IMapper mapper) : base(service, mapper)
        {
        }

        [HttpGet("Get-AllAsync")]
        public async Task<ActionResult<IReadOnlyList<ReturnStudentDTO>>> index()
        => Ok(await _service.Student.GetAllAsyncWithSubCourse());

        [HttpGet("get-by-id")]
        public async Task<ActionResult<ReturnStudentDTO>> get(Guid id)
        => Ok(await _service.Student.GetByIdAsyncWithSubCourse(id));
        [HttpPost("Add-Student")]
        public async Task<ActionResult> add([FromBody] StudentDTO student)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    var result = mapper.Map<Student>(student);
                    Random random = new Random();
                    if (result.Gender == Gender.Male)
                    {
                        result.Image = $"/Images/Male/{random.Next(1, 18)}.png";
                    }
                    else
                    {
                        result.Image = $"/Images/Female/{random.Next(1, 15)}.png";
                    }
                    await _service.Student.AddAsync(result);
                    return Ok(new BaseResponse(200, "Item Has been Added"));
                }
                return BadRequest(new BaseResponse(400, "bad request"));
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }


        [HttpPut("Update-Student")]
        public async Task<ActionResult> Update([FromBody] UpdateStudentDTO student)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _service.Student.UpdateAsync(mapper.Map<Student>(student));
                    return Ok(new BaseResponse(200, "Item Has been Updated"));
                }
                return BadRequest(new BaseResponse(400, "bad request"));
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("Delete-Student")]
        public async Task delelte(Guid id)
       => await _service.Student.DeleteByGuidAsync(id);
    }
}
