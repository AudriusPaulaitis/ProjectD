using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace ProjectD
{
    public class ApiCaller
    {

        //get userdata
        public static string GetUserdata()
        {
            var url = $@"https://api.fitbit.com/1/user/-/profile.json";

            var httpRequest = (HttpWebRequest)WebRequest.Create(url);

            httpRequest.Accept = "application/json";
            httpRequest.Headers["Authorization"] = "Bearer eyJhbGciOiJIUzI1NiJ9.eyJhdWQiOiIyM0IyN1oiLCJzdWIiOiI5RkNDMjIiLCJpc3MiOiJGaXRiaXQiLCJ0eXAiOiJhY2Nlc3NfdG9rZW4iLCJzY29wZXMiOiJ3aHIgd3BybyB3bnV0IHdzbGUgd3dlaSB3c29jIHdhY3Qgd3NldCB3bG9jIiwiZXhwIjoxNjU1MzE3ODk0LCJpYXQiOjE2MjM3ODI5NjB9.LrXwR3r_hiora_F1_R7ah6bktC8dzkjZUGtLe-HU_WU";


            var httpResponse = (HttpWebResponse)httpRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();
                return result;
            }
        }

        //send date and start&end time to get fitbit heartactivity data
        public static string GetAverageHeartRate(string date, string startAverageTime, string endAverageTime)
        {
            var url = $@"https://api.fitbit.com/1/user/-/activities/heart/date/" + date + "/" + date + "/1min/time/" + startAverageTime + "/"+ endAverageTime + ".json";

            var httpRequest = (HttpWebRequest)WebRequest.Create(url);

            httpRequest.Accept = "application/json";
            httpRequest.Headers["Authorization"] = "Bearer eyJhbGciOiJIUzI1NiJ9.eyJhdWQiOiIyM0IyN1oiLCJzdWIiOiI5RkNDMjIiLCJpc3MiOiJGaXRiaXQiLCJ0eXAiOiJhY2Nlc3NfdG9rZW4iLCJzY29wZXMiOiJ3aHIgd3BybyB3bnV0IHdzbGUgd3dlaSB3c29jIHdhY3Qgd3NldCB3bG9jIiwiZXhwIjoxNjU1MzE3ODk0LCJpYXQiOjE2MjM3ODI5NjB9.LrXwR3r_hiora_F1_R7ah6bktC8dzkjZUGtLe-HU_WU";


            var httpResponse = (HttpWebResponse)httpRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();
                return result;
            }
        }

        public static string GetListOfActivityHistory()
        {
            string date = DateTime.Now.ToString("yyyy-MM-dd");
            var url = $@"https://api.fitbit.com/1/user/-/activities/list.json?sort=asc&offset=0&limit=100&beforeDate=" + date;

            var httpRequest = (HttpWebRequest)WebRequest.Create(url);

            httpRequest.Accept = "application/json";
            httpRequest.Headers["Authorization"] = "Bearer eyJhbGciOiJIUzI1NiJ9.eyJhdWQiOiIyM0IyN1oiLCJzdWIiOiI5RkNDMjIiLCJpc3MiOiJGaXRiaXQiLCJ0eXAiOiJhY2Nlc3NfdG9rZW4iLCJzY29wZXMiOiJ3aHIgd3BybyB3bnV0IHdzbGUgd3dlaSB3c29jIHdhY3Qgd3NldCB3bG9jIiwiZXhwIjoxNjU1MzE3ODk0LCJpYXQiOjE2MjM3ODI5NjB9.LrXwR3r_hiora_F1_R7ah6bktC8dzkjZUGtLe-HU_WU";


            var httpResponse = (HttpWebResponse)httpRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();
                return result;
            }
        }



    }
}
