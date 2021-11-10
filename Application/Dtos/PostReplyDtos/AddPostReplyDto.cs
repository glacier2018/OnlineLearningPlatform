using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Dtos.PostReplyDtos
{
    public class AddPostReplyDto
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public int PostId { get; set; }
        public int? TargetPostReplyId { get; set; }
    }
}