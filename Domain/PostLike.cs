using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain
{
    public class PostLike
    {
        public int Id { get; set; }
        public int LikeType { get; set; }

        //Navigation Property and FKs
        public ApplicationUser ApplicationUser { get; set; }
        public int ApplicationUserId { get; set; }

        public Post Post { get; set; }
        public int PostId { get; set; }


    }
}