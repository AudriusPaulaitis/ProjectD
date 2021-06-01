using Microsoft.AspNetCore.Mvc;
using ProjectD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectD.Controllers
{
    public class TrainingController : Controller
    {
        public Dictionary<string, List<string>> TrainingDict { get; set; }
        public TrainingController()
        {
            TrainingDict = new Dictionary<string, List<string>>();
        }
        public IActionResult Trainingen()
        {
            int indexN = 0;
            switch (indexN)
            {
                case 0:
                    TrainingDict.Add("Week 1", new List<string>() { "training 4", "training 5" });
                    TrainingDict.Add("Week 2", new List<string>() { "training 6", "training 8" });
                    break;
                case 1:
                    TrainingDict.Add("Week 1", new List<string>() { "training 4", "training 5" });
                    TrainingDict.Add("Week 2", new List<string>() { "training 6", "training 8" });
                    break;
            }
            return View(TrainingDict);
        }
    }
}
