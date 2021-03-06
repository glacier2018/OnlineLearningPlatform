using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Identity;

namespace Domain
{
    public class ApplicationUser : IdentityUser<int>
    {
        public string Photo { get; set; }
        public int UserType { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ForgotPasswordToken { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        //Navigation properties
        public ICollection<PostReply> PostReplies { get; set; }
        public ICollection<Post> Posts { get; set; }
        public ICollection<Photo> Photos { get; set; }
        public ICollection<PostLike> PostLikes { get; set; }
        
    }
}