using AutoMapper;
using Controllers.Users;
using E_commorec.core.InterFace;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace E_comorec.API.Controllers.Users
{
    [Authorize(Roles = "User")]
    public class MyCoursesController : BaseController
    {
        public MyCoursesController(IUnitOfWork service, IMapper mapper) : base(service, mapper)
        {
        }
        [HttpGet("Get-All-Courses")]
        public async Task<ActionResult> get()
        => Ok(await _service.SubCourse.GetCoursesForStudent(User?.FindFirst(ClaimTypes.Email)?.Value));

        [HttpGet("Get-Course/{id}")]
        public async Task<ActionResult> get(int id)
        => Ok(await _service.SubCourse.GetCourseForStudent(User?.FindFirst(ClaimTypes.Email)?.Value, id));

    }
}
