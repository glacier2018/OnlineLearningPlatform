using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Core;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BaseApiController : ControllerBase
    {
        protected ActionResult HandleResponse<T>(Response<T> res)
        {
            if (res == null) return NotFound();

            if (res.Success && res.Data != null) return Ok(res);

            if (res.Success && res.Data == null) return NotFound();

            return BadRequest(res);

        }
    }
}