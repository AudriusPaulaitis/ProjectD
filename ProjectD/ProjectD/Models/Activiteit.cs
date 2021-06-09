using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectD.Models
{
    /*
    public class Activities
    {
        public Activity[] activities { get; set; }
    }*/

    public class Activiteit
    {
        public int ActiveDuration { get; set; }
        //public Activitylevel[] activityLevel { get; set; }
        public string ActivityName { get; set; }
        //public int activityTypeId { get; set; }
        public string AverageHeartRate { get; set; }
        public string Calories { get; set; }
        //public string caloriesLink { get; set; }
        public string Distance { get; set; }
        public string DistanceUnit { get; set; }
        //public int duration { get; set; }
        public string ElevationGain { get; set; }
        //public bool hasActiveZoneMinutes { get; set; }
        //public string heartRateLink { get; set; }
        //public Heartratezone[] HeartRateZones { get; set; }
        //public DateTime lastModified { get; set; }
        //public long logId { get; set; }
        //public string logType { get; set; }
        //public Manualvaluesspecified manualValuesSpecified { get; set; }
        public string OriginalDuration { get; set; }
        public string OriginalStartTime { get; set; }
        //public Source source { get; set; }
        public string Speed { get; set; }
        public string StartTime { get; set; }
        public string Steps { get; set; }
        //public string tcxLink { get; set; }
        //public float pace { get; set; }
    }

    /*public class Heartratezone
    {
        public int max { get; set; }
        public int min { get; set; }
        public int minutes { get; set; }
        public string name { get; set; }
    }*/

    /*
    public class Manualvaluesspecified
    {
        public bool calories { get; set; }
        public bool distance { get; set; }
        public bool steps { get; set; }
    }*/

    /*
    public class Source
    {
        public string id { get; set; }
        public string name { get; set; }
        public string[] trackerFeatures { get; set; }
        public string type { get; set; }
        public string url { get; set; }
    }*/

    /*
    public class Activitylevel
    {
        public int minutes { get; set; }
        public string name { get; set; }
    }*/


}
