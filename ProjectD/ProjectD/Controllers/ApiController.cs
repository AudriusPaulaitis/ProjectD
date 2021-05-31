using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectD.Controllers
{
    public class ApiController : Controller
    {
        public string Index()
        {
            //return "This is my default action...";
            var json = ApiCaller.GetUserdata();
            return json;
        }
    }
}
