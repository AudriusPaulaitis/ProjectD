using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
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

        public double[] CheckVo2Max(double vo2, string gender)
        { 
            if (gender == "Male")
            {
                if (35.4 > vo2 && vo2 > 31.5)
                    return new double[] { 0.9, 30.0 };
                else if (40.9 > vo2 && vo2 > 35.5)
                    return new double[] { 1.1, 20.0 };
                else if (vo2 > 41.0)
                    return new double[] { 1.2, 15.0 };
                else //Lower than 31.5
                    return new double[]{ 0.8, 35.0 };
            }
            if (26.9 > vo2 && vo2 > 22.8)
                return new double[] { 0.9, 30.0 };
            else if (31.4 > vo2 && vo2 > 27.0)
                return new double[] { 1.1, 20.0 };
            else if (vo2 > 31.4)
                return new double[] { 1.2, 15.0 };
            else //Lower than 22.8
                return new double[] { 0.8, 35.0 };

        }

        [HttpPost]
        public IActionResult Trainingen(int TrainingFrequency, int WeeklyGoal, int Goal)
        {
            if (TrainingFrequency > 50 || WeeklyGoal > 100 || Goal > 100)
            {
                TempData["Error"] = "Niet realistisch";
                return View("../Home/Index");
            }

            var user = ApiCaller.GetUserdata();
            var date = $"{DateTime.Now.Date.Year}-{DateTime.Now.Date.ToString().Substring(3,2)}-{DateTime.Now.Date.ToString().Substring(0, 2)}";
            var RestHr = ApiCaller.GetAverageHeartRate(date, "7:00:00", "9:00:00");
            var userdata = JObject.Parse(user)["user"];
            var heartdata = JObject.Parse(RestHr)["activities-heart"][0]["value"];
            if ((int)heartdata == 0) heartdata = 80;
            var vo2Max = ((220 - (int)userdata["age"]) / (double)heartdata) * 15;
            if (WeeklyGoal > Goal)
            {
                TempData["Error"] = "Wekelijks doel moet kleiner zijn dan uw doel!";
                return View("../Home/Index");
            }
            int TF = TrainingFrequency;
            var tm = 0;
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
                    wg *= CheckVo2Max(vo2Max, (string)userdata["gender"])[0];
                    training.Time = (int)CheckVo2Max(vo2Max, (string)userdata["gender"])[1];
                    TrainingFrequency = TF;
                    training.TrainingDict.Add($"Week {w}", TrainingList);
                }
                db.SaveChanges();
                return View(training);
            }
            

            
        }
    }
}
