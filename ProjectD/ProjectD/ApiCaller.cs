using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace ProjectD
{
    class ApiCaller
    {

        public static string GetUserdata()
        {
            //string date = DateTime.Now.ToString("yyyy-MM-dd");
            var url = $@"https://api.fitbit.com/1/user/-/profile.json";

            var httpRequest = (HttpWebRequest)WebRequest.Create(url);

            httpRequest.Accept = "application/json";
            httpRequest.Headers["Authorization"] = "Bearer eyJhbGciOiJIUzI1NiJ9.eyJhdWQiOiIyMzlaUTgiLCJzdWIiOiI5RkMySzkiLCJpc3MiOiJGaXRiaXQiLCJ0eXAiOiJhY2Nlc3NfdG9rZW4iLCJzY29wZXMiOiJyc29jIHJhY3QgcnNldCBybG9jIHJ3ZWkgcmhyIHJudXQgcnBybyByc2xlIiwiZXhwIjoxNjUzOTg3NTc0LCJpYXQiOjE2MjI0NTIwNTN9.9b1rV51bEo-Z_rdAsXMF9opjC4cG0M9z0YTAyBfy28M";


            var httpResponse = (HttpWebResponse)httpRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();
                return result;
            }
        }
    }
}
