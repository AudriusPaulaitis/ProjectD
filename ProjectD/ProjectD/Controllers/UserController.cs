using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ProjectD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectD.Controllers
{
    public class UserController : Controller
    {
        public User user;
        public UserController()
        {
            user = new User();
        }
        public IActionResult UserData()
        {
            var json = ApiCaller.GetUserdata();
            var data = JObject.Parse(json)["user"];
            user.Username = (string)data["fullName"];
            user.MemberSince = (string)data["memberSince"];
            user.ImageUrl = (string)data["avatar"];
            return View(user);
        }
    }
}
