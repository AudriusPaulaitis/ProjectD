using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProjectD.Models;


namespace ProjectD.Controllers
{
    public class GeschiedenisController : Controller
    {
        public Activiteit activities;

        public GeschiedenisController() {
            activities = new Activiteit();
        }


        public IActionResult Geschiedenis()
        {
            var json = ApiCaller.GetListOfActivityHistory();
            var data = JObject.Parse(json)["activities"];
            var activitylist = new List<Activiteit>();

            foreach (var item in data)
            {
               
                activitylist.Add(new Activiteit
                {
                    ActiveDuration = (item["activeDuration"].ToObject<int>()/1000),
                    ActivityName = item["activityName"].ToString(),
                    Calories = item["calories"].ToString(),
                    //AverageHeartRate = item["averageHeartRate"].ToString(),
                    //Distance = item["distance"].ToString(),
                    //DistanceUnit = item["distanceUnit"].ToString(),
                    //ElevationGain = item["elevationGain"].ToString(),
                    //OriginalDuration = item["originalDuration"].ToString(),
                    //OriginalStartTime = item["originalStartTime"].ToString(),
                    //Speed = item["speed"].ToString(),
                    StartTime = item["startTime"].ToString(),
                    Steps = item["steps"].ToString()
                });
            }
           


            return View(activitylist);
        }

        /*
        public string checkEmpty(string datafield) {
            if(datafield)
            return "leeg";
        }*/

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = System.Diagnostics.Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
