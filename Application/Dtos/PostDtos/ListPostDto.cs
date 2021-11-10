using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Dtos.PostReplyDtos;
using Domain;

namespace Application.Dtos.PostDtos
{
    public class ListPostDto : AddPostDto
    {
        public int Id { get; set; }
        // public string Title { get; set; }
        // public string Description { get; set; }
        // public string Content { get; set; }
        // public int PostCategoryId { get; set; }
        // public int[] TagIds { get; set; }

        public ICollection<TagPostDto> Tags { get; set; }

        public ICollection<ListPostReplyDto> PostReplies { get; set; }

        public int ApplicationUserId { get; set; }
    }
}