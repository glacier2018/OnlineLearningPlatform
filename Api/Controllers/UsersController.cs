using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Dtos;
using Application.Users;
using Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Api.Controllers
{
    public class UsersController : BaseApiController
    {

        [HttpGet("GetAllUsers")]
        public async Task<ActionResult<User>> GetAllUsers()
        {
            return HandleResponse(await Mediator.Send(new GetAllUsers.Query()));
        }

        [HttpPost("UserLogin")]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            return HandleResponse(await Mediator.Send(new Login.Query { LoginDto = loginDto }));
        }
        [HttpPost("UserRegister")]
        public async Task<IActionResult> Register(RegisterDto registerDto)
        {
            return HandleResponse(await Mediator.Send(new Register.Command { RegisterDto = registerDto }));
        }
    }
}