using AutoMapper;
using E_commorec.core.InterFace;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_comorec.API.Controllers
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
