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
        public Training training { get; set; }
        public TrainingController()
        {
            training = new Training();
            training.TrainingDict = new Dictionary<string, List<string>>();
        }
        public IActionResult Trainingen(int TrainingFrequency, int WeeklyGoal, int Goal)
        {
            int TF = TrainingFrequency;
            var wg = (double)WeeklyGoal;
            training.Weeks = (Goal / WeeklyGoal);
            for (int w = 1; w <= training.Weeks; w++)
            {
                var TrainingList = new List<string>();
                TrainingList.Add($"Duurloop training {Math.Round(wg / 2, 1)} KM");
                while (TrainingFrequency - 1 != 0)
                {
                    TrainingList.Add($"Normale training {Math.Round(wg / 2, 1)} KM");
                    TrainingFrequency -= 1;
                }
                wg *= 1.1;
                TrainingFrequency = TF;
                training.TrainingDict.Add($"Week {w}", TrainingList);
            }
            
            return View(training);
        }
    }
}
