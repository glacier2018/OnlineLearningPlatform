using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Core;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BaseApiController : ControllerBase
    {
        protected IMediator _meidator;
        
        protected IMediator Mediator => _meidator ??= HttpContext.RequestServices.GetService<IMediator>();
        protected ActionResult HandleResponse<T>(Response<T> res)
        {
            if (res == null) return NotFound();

            if (res.Success && res.Data != null) return Ok(res);

            if (res.Success && res.Data == null) return NotFound();

            return BadRequest(res);

        }
    }
}