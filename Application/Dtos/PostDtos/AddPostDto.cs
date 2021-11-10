using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;

namespace Application.Dtos.PostDtos
{
    public class AddPostDto
    {

        public string Title { get; set; }
        public string Description { get; set; }
        public string Content { get; set; }
        public int PostCategoryId { get; set; }
        public int[] TagIds { get; set; }

    }
}