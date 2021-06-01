using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectD.Models
{
    public class User
    {
        [JsonProperty("fullame")]
        public string Fullname { get; set; }
        [JsonProperty("age")]
        public string Age { get; set; }
        [JsonProperty("averageDailySteps")]
        public string AverageDailySteps { get; set; }
        [JsonProperty("challengesBeta")]
        public bool ChallengesBeta { get; set; }
        [JsonProperty("dateOfBirth")]
        public string DateOfBirth { get; set; }
        [JsonProperty("displayName")]
        public string DisplayName { get; set; }
        [JsonProperty("distanceUnit")]
        public string DistanceUnit { get; set; }
        [JsonProperty("firstName")]
        public string FirstName { get; set; }
        [JsonProperty("gender")]
        public string Gender { get; set; }
        [JsonProperty("glucoseUnit")]
        public string GlucoseUnit { get; set; }
        [JsonProperty("height")]
        public string Height { get; set; }
        [JsonProperty("heightUnit")]
        public string HeightUnit { get; set; }
        [JsonProperty("languageLocale")]
        public string LanguageLocale { get; set; }
        [JsonProperty("lastName")]
        public string LastName { get; set; }
        [JsonProperty("locale")]
        public string Locale { get; set; }
        [JsonProperty("memberSince")]
        public string MemberSince { get; set; }
        [JsonProperty("sleepTracking")]
        public string SleepTracking { get; set; }
        [JsonProperty("startDayOfWeek")]
        public string StartDayOfWeek { get; set; }
        [JsonProperty("strideLengthRunning")]
        public string StrideLengthRunning { get; set; }
        [JsonProperty("strideLengthRunningType")]
        public string StrideLengthRunningType { get; set; }
        [JsonProperty("strideLengthWalking")]
        public string StrideLengthWalking { get; set; }
        [JsonProperty("strideLengthWalkingType")]
        public string StrideLengthWalkingType { get; set; }
        [JsonProperty("swimUnit")]
        public string SwimUnit { get; set; }
        [JsonProperty("waterUnit")]
        public string WaterUnit { get; set; }
        [JsonProperty("waterUnitName")]
        public string WaterUnitName { get; set; }
        [JsonProperty("weight")]
        public string Weight { get; set; }
        [JsonProperty("weightUnit")]
        public string WeightUnit { get; set; }
        public string ImageUrl { get; set; }
        public string AvrgHeartRate { get; set; }
    }
}
