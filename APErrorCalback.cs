using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace SimpleAnswerPhone
{

    public class APErrorCalback
    {

        public APErrorCalback()
        {

        }



        [FunctionName("APErrorCalback")]
        public async void Run([HttpTrigger(AuthorizationLevel.Function, "post", Route = null)] HttpRequest req, ILogger log)
        {
            log.LogInformation("SMS with the SID " + req.Form["SmsSid"] + " was " + req.Form["SmsStatus"]+" on "+DateTime.Now);
            
        }
    }
}
