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
        public DateTime CreateAt { get; set; }
        public DateTime UpdatedAt { get; set; }


        //Navigation Property and FKs
        public ApplicationUser ApplicationUser { get; set; }
        public int ApplicationUserId { get; set; }
        public Post Post { get; set; }
        public int PostId { get; set; }

    }
}