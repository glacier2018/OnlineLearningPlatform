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
        public async Task<ActionResult<ApplicationUser>> GetAllUsers()
        {
            return HandleResponse(await Mediator.Send(new GetAllUsers.Query()));
        }
        [HttpGet("GetUserById")]
        public async Task<ActionResult<OneUserDto>> GetOneUser(int id)
        {
            return HandleResponse(await Mediator.Send(new GetOneUser.Query { Id = id }));
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
        [HttpDelete("DeleteUser")]
        public async Task<IActionResult> Delete(int id)
        {
            return HandleResponse(await Mediator.Send(new DeleteUser.Command { Id = id }));
        }

        [HttpPut("UpdateUser")]
        public async Task<IActionResult> Update(UpdateUserDto updateUserDto)
        {
            return HandleResponse(await Mediator.Send(new UpdateUser.Command { UpdateUserDto = updateUserDto }));
        }

        // [HttpGet("testing")]
        // public async Task<IActionResult> Testing()
        // {
        //     return HandleResponse(await Mediator.Send(new Testing.Query()));
        // }
    }
}