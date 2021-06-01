using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectD.Models
{
    public class User
    {
        public string Username { get; set; }
        public string MemberSince { get; set; }
        public string ImageUrl { get; set; }
    }
}
