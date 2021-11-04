using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain
{
    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public bool IsActive { get; set; }

        //Navigation Properties and FKs:

        public PostCategory PostCategory { get; set; }
        public int? PostCategoryId { get; set; }

        public ApplicationUser ApplicationUser { get; set; }
        public int? ApplicationUserId { get; set; }


        public ICollection<PostReply> PostReplies { get; set; }

        public ICollection<Photo> Photos { get; set; }
        public ICollection<TagPost> TagPosts { get; set; }
        public ICollection<PostLike> PostLikes { get; set; }

    }
}