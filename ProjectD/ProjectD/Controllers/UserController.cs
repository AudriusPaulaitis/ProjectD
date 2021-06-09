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
        public DataContext context { get; set; }
        public UserController(DataContext dataContext)
        {
            user = new User();
            context = dataContext;
        }

        public IActionResult UserData()
        {
            var json = ApiCaller.GetUserdata();
            var data = JObject.Parse(json)["user"];

            user.Fullname =     data["fullName"].ToString();
            user.Age =          data["age"].ToString();
            user.DateOfBirth =  data["dateOfBirth"].ToString();
            user.Gender =       data["gender"].ToString();
            user.Height =       data["height"].ToString();
            user.Weight =       data["weight"].ToString();
            user.AverageDailySteps = data["averageDailySteps"].ToString();
            user.MemberSince = (string)data["memberSince"];
            user.ImageUrl = (string)data["avatar"];
            var test = context.Trainings.ToList();
            user.Completed = Int32.Parse(test[0].WeekTraining.Split("|").Last());
            string date = $"{DateTime.Now.Date.Year}-{DateTime.Now.Date.ToString().Substring(3, 2)}-{DateTime.Now.Date.ToString().Substring(0, 2)}";
            string url = ApiCaller.GetAverageHeartRate(date,"16:00:00","17:00:00");
            user.AvrgHeartRate = url;
            return View(user);
        }


    }
}
