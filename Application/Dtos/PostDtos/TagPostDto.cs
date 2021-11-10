using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;

namespace Application.Dtos.PostDtos
{
    public class TagPostDto
    {
        public string TagName { get; set; }
        public int TagId { get; set; }
    }
}