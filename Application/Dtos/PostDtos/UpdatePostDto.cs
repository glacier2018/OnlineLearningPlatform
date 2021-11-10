using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Dtos.PostDtos
{
    public class UpdatePostDto : AddPostDto
    {
        public int PostId { get; set; }
    }
}