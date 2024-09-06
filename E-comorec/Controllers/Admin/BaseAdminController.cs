using AutoMapper;
using E_commorec.core.InterFace;
using Microsoft.AspNetCore.Mvc;

namespace E_comorec.API.Controllers.Admin
{
    [Route("api/[controller]")]
    [ApiController]
    // [Authorize(Roles = "SupAdmin")]
    public class BaseAdminController : ControllerBase
    {
        protected readonly IUnitOfWork _service;
        protected readonly IMapper mapper;

        public BaseAdminController(IUnitOfWork service, IMapper mapper)
        {
            _service = service;
            this.mapper = mapper;
        }
    }
}
