using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Api.Controllers
{
    public class UsersController : BaseApiController
    {
        // private readonly UserManager<User> _userManager;
        // private readonly SignInManager<User> _signInManager;
        // private readonly DataContext _context;
        // public UsersController(UserManager<User> userManager, SignInManager<User> signInManager, DataContext context)
        // {
        //     _context = context;
        //     _signInManager = signInManager;
        //     _userManager = userManager;
        // }

        [HttpGet("GetAllUsers")]
        public async Task<ActionResult<User>> GetAllUsers()
        {
            // return Ok(await _context.Users.ToListAsync());
            // return Ok(await _userManager.Users.ToListAsync());
            // return HandleResponse(_)
            throw new NotImplementedException();
        }
    }
}