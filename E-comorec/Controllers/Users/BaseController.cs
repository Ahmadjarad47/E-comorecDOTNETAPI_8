using AutoMapper;
using E_commorec.core.InterFace;
using Microsoft.AspNetCore.Mvc;

namespace Controllers.Users
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController : ControllerBase
    {
        protected readonly IUnitOfWork _service;
        protected readonly IMapper mapper;
        public BaseController(IUnitOfWork service, IMapper mapper)
        {
            _service = service;
            this.mapper = mapper;
        }
    }
}
