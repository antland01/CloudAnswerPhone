using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;

namespace SimpleAnswerPhone
{

    public class APErrorCalback(ILogger<APErrorCalback> logger)
    {

        private readonly ILogger<APErrorCalback> _logger = logger;

        [Function("APErrorCalback")]
        public async Task RunAsync([HttpTrigger(AuthorizationLevel.Function, "post")] HttpRequestData req)
        {
            string body = await new StreamReader(req.Body).ReadToEndAsync();
            string[] bodyArray = body.Split('&');
            Dictionary<string,string> webhookRequest = bodyArray.ToDictionary(mc => mc.Split('=')[0], mc => mc.Split('=')[1], StringComparer.OrdinalIgnoreCase);

            _logger.LogInformation("SMS with the SID " + webhookRequest["SmsSid"] + " was " + webhookRequest["SmsStatus"]+" on "+DateTime.Now);
           
        }
    }
}
