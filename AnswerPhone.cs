using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace SimpleAnswerPhone
{

    public class AnswerPhone(ITwillioService TwillioService, ILogger<AnswerPhone> logger)
    {
        private readonly ITwillioService _TwillioService = TwillioService;
        private readonly ILogger<AnswerPhone> _logger = logger;

        [Function("AnswerPhone")]
        public async Task<HttpResponseData> Run([HttpTrigger(AuthorizationLevel.Function, "post")] HttpRequestData req)
        {

            HttpResponseData response = req.CreateResponse(HttpStatusCode.OK);
            response.Headers.Remove("Content-Type");
            response.Headers.Add("Content-Type", "application/xml");
            await response.WriteStringAsync(_TwillioService.ReplyWithMessageToCall("You have reached the phone of Anthony Smith. As of June 9th 2020, I no longer reside in the United Kingdom. Please email me if you wish to contact me. Thank you.", "Polly.Russell"));



            string body = await new StreamReader(req.Body).ReadToEndAsync();
            string[] bodyArray = body.Split('&');
            Dictionary<string, string> webhookRequest = bodyArray.ToDictionary(mc => mc.Split('=')[0], mc => mc.Split('=')[1], StringComparer.OrdinalIgnoreCase);


            _logger.LogInformation("New Call received");

            _TwillioService.SendSMS("200. Your UK Number received a Call from " + webhookRequest["From"], Environment.GetEnvironmentVariable("MyNumber", EnvironmentVariableTarget.Process));


            return response;

        }
    }
}
