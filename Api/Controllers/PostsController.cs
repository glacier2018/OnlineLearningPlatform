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
        public async Task<ActionResult<List<ListPostDto>>> GetById(int id)
        {
            return HandleResponse(await Mediator.Send(new GetPostById.Query { Id = id }));
        }
        [HttpGet("GetAllPosts")]
        public async Task<ActionResult<List<ListPostDto>>> GetAll()
        {
            return HandleResponse(await Mediator.Send(new GetAllPosts.Query()));
        }
        [HttpPost("AddPost")]
        public async Task<ActionResult<Post>> AddPost(AddPostDto AddPostDto)
        {
            return HandleResponse(await Mediator.Send(new AddPost.Command { AddPostDto = AddPostDto }));
        }
        [HttpDelete("DeletePost")]
        public async Task<IActionResult> DeletePost(int id)
        {
            return HandleResponse(await Mediator.Send(new DeletePost.Command { Id = id }));
        }
        [HttpPut("UpdatePost")]
        public async Task<IActionResult> UpdatePost(UpdatePostDto updatePostDto)
        {
            return HandleResponse(await Mediator.Send(new UpatePost.Command { UpdatePostDto = updatePostDto }));
        }
        [HttpPost("AddPostTag")]
        public async Task<IActionResult> AddPostTag(int postId, int tagId)
        {
            return HandleResponse(await Mediator.Send(new AddPostTag.Command { PostId = postId, TagId = tagId }));
        }
        [HttpPost("AddPostReply")]
        public async Task<IActionResult> AddPostReply(AddPostReplyDto addPostReplyDto)
        {
            return HandleResponse(await Mediator.Send(new AddPostReply.Command { AddPostReplyDto = addPostReplyDto }));
        }

    }
}