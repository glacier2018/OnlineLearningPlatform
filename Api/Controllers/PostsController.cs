using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Dtos;
using Application.Posts;
using Application.Users;
using Domain;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    public class PostsController : BaseApiController
    {
        [HttpGet("GetPostById")]
        public async Task<ActionResult<List<Post>>> GetById(int id)
        {
            return HandleResponse(await Mediator.Send(new GetPostById.Query { Id = id }));
        }
        [HttpGet("GetAllPosts")]
        public async Task<ActionResult<List<Post>>> GetAll()
        {
            return HandleResponse(await Mediator.Send(new GetAllPosts.Query()));
        }
        [HttpPost("AddPost")]
        public async Task<ActionResult<Post>> AddPost(PostDto postDto)
        {
            return HandleResponse(await Mediator.Send(new AddPost.Command { PostDto = postDto }));
        }
        [HttpDelete("DeletePost")]
        public async Task<IActionResult> DeletePost(int id)
        {
            return HandleResponse(await Mediator.Send(new DeletePost.Command { Id = id }));
        }

    }
}