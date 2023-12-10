using System;
using System.Threading.Tasks;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using System.Net;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace SimpleAnswerPhone
{

    public class AnswerSms(ITwillioService TwillioService, ILogger<AnswerSms> logger)
    {
        private readonly ITwillioService _TwillioService = TwillioService;
        private readonly ILogger<AnswerSms> _logger = logger;

        [Function("AnswerSms")]
        public async Task<HttpResponseData> Run([HttpTrigger(AuthorizationLevel.Function, "post")] HttpRequestData req)
        {
            _logger.LogInformation("New Sms received");

            HttpResponseData response = req.CreateResponse(HttpStatusCode.OK);
            response.Headers.Remove("Content-Type");
            response.Headers.Add("Content-Type", "application/xml");
            await response.WriteStringAsync(_TwillioService.ReplyWithMessageToSms("Thank you for your SMS message. Due to the current on going Covid-19 situation. As of June 9th 2020, I no longer reside in the United Kingdom. Please email me if you wish to contact me. Thank you and stay safe."));


            string body = await new StreamReader(req.Body).ReadToEndAsync();
            string[] bodyArray = body.Split('&');
            Dictionary<string, string> webhookRequest = bodyArray.ToDictionary(mc => mc.Split('=')[0], mc => mc.Split('=')[1], StringComparer.OrdinalIgnoreCase);



            _TwillioService.SendSMS("Your UK Number received a SMS from " + webhookRequest["From"].ToString(), Environment.GetEnvironmentVariable("MyNumber", EnvironmentVariableTarget.Process));

            return response;
        }
    }
}
