using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain
{
    public class Photo
    {
        public string Id { get; set; }
        public string PhotoUrl { get; set; }
        public bool IsMain { get; set; }

        //Navigation property and FKs
        public ApplicationUser ApplicationUser { get; set; }
        public int ApplicationUserId { get; set; }

    }
}