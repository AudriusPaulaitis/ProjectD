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

        public static string GetUserdata()
        {
            //string date = DateTime.Now.ToString("yyyy-MM-dd");
            var url = $@"https://api.fitbit.com/1/user/-/profile.json";

            var httpRequest = (HttpWebRequest)WebRequest.Create(url);

            httpRequest.Accept = "application/json";
            httpRequest.Headers["Authorization"] = "Bearer eyJhbGciOiJIUzI1NiJ9.eyJhdWQiOiIyM0IyN1oiLCJzdWIiOiI5RkNDMjIiLCJpc3MiOiJGaXRiaXQiLCJ0eXAiOiJhY2Nlc3NfdG9rZW4iLCJzY29wZXMiOiJ3aHIgd251dCB3cHJvIHdzbGUgd3dlaSB3c29jIHdhY3Qgd3NldCB3bG9jIiwiZXhwIjoxNjIzMDk3MDQzLCJpYXQiOjE2MjI0OTIyNDN9.pQWyrFTQaFf52QghJ5XfLg6YD0tYDbDUUC8Da2jq2Jc";


            var httpResponse = (HttpWebResponse)httpRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();
                return result;
            }
        }
    }
}
