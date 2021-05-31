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
        public List<string> TrainingList { get; set; }
        public TrainingController()
        {
            TrainingList = new List<string>();
        }
        public IActionResult Trainingen()
        {
            int indexN = 0;
            switch (indexN)
            {
                case 0:
                    TrainingList.Add("training 1");
                    TrainingList.Add("training 4");
                    TrainingList.Add("training 5");
                    break;
                case 1:
                    TrainingList.Add("training 2");
                    TrainingList.Add("training 3");
                    break;
            }
            return View(TrainingList);
        }
    }
}
