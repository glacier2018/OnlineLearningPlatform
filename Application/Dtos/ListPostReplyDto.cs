using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Dtos
{
    public class ListPostReplyDto
    {
        public int PostReplyId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public int PostId { get; set; }
        public int? TargetPostReplyId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}