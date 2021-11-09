using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain
{
    public class PostReply
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreateAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;


        //Navigation Property and FKs
        public ApplicationUser ApplicationUser { get; set; }
        public int ApplicationUserId { get; set; }
        public Post Post { get; set; }
        public int PostId { get; set; }
        public PostReply TargetPostReply { get; set; }

        public int? TargetPostReplyId { get; set; }



    }
}