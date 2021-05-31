using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectD.Controllers
{
    public class UserController : Controller
    {
        public IActionResult UserData()
        {
            return View();
        }
    }
}
