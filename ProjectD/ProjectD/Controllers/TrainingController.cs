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
        public TrainingModel training { get; set; }
        public DataContext context { get; set; }
        public TrainingController(DataContext dataContext)
        {
            training = new TrainingModel();
            training.TrainingDict = new Dictionary<string, List<string>>();
            context = dataContext;
        }


        [HttpGet]
        public IActionResult Trainingen(string[] trainingList)
        {
            using (var db = context)
            {
                if (trainingList.Length != 0)
                {
                    foreach (var training in trainingList)
                    {
                        db.RemoveRange(db.Trainings.Where(x => x.WeekTraining == training));
                    }
                    db.SaveChanges();
                }
                var weeks = context.Trainings.Select(x => x.WeekId).Distinct();
                training.Weeks = weeks.Count();
                var totaltrainings = context.Trainings.ToList();
                for (int w = 1; w <= weeks.Count(); w++)
                {
                    var TrainingList = new List<string>();
                    foreach (var t in totaltrainings.Where(x => x.WeekId == w))
                    {
                        TrainingList.Add(t.WeekTraining);
                    }
                    training.TrainingDict.Add($"Week {w}", TrainingList);
                }
            }
            return View(training);

        }

        [HttpPost]
        public IActionResult Trainingen(int TrainingFrequency, int WeeklyGoal, int Goal)
        {
            
            if (WeeklyGoal > Goal)
            {
                TempData["Error"] = "Wekelijks doel moet kleiner zijn dan uw doel!";
                return View("../Home/Index");
            }
            int TF = TrainingFrequency;
            var wg = (double)WeeklyGoal;
            int specialNr = 1;
            training.Weeks = (Goal / WeeklyGoal);
            using (var db = context)
            {
                db.Trainings.RemoveRange(db.Trainings.Where(x => x.WeekTraining.Contains("training")));
                for (int w = 1; w <= training.Weeks; w++)
                {
                    var TrainingList = new List<string>();
                    context.Trainings.Add(new Training { WeekId = w, WeekTraining = $"{w}.{specialNr} Duurloop training {Math.Round(wg / 2, 1)} KM" });
                    TrainingList.Add($"{w}.{specialNr} Duurloop training {Math.Round(wg / 2, 1)} KM");
                    specialNr += 1;
                    while (TrainingFrequency - 1 != 0)
                    {
                        context.Trainings.Add(new Training { WeekId = w, WeekTraining = $"{w}.{specialNr} Normale training {Math.Round(wg / 2, 1)} KM" });
                        TrainingList.Add($"{w}.{specialNr} Normale training {Math.Round(wg / 2, 1)} KM");
                        TrainingFrequency -= 1;
                        specialNr += 1;
                    }
                    wg *= 1.1;
                    TrainingFrequency = TF;
                    training.TrainingDict.Add($"Week {w}", TrainingList);
                }
                db.SaveChanges();
                return View(training);
            }
            

            
        }
    }
}
