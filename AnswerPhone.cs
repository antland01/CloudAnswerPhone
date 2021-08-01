using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace SimpleAnswerPhone
{

    public class AnswerPhone
    {
        private readonly ITwillioService _TwillioService;

        public AnswerPhone(ITwillioService TwillioService)
        {
            _TwillioService = TwillioService;
        }



        [FunctionName("AnswerPhone")]
        public async Task<IActionResult> Run([HttpTrigger(AuthorizationLevel.Function, "post", Route = null)] HttpRequest req, ILogger log)
        {
            log.LogInformation("New Call received");

             _TwillioService.SendSMS("Your UK Number received a Call from " + req.Form["From"], Environment.GetEnvironmentVariable("MyNumber", EnvironmentVariableTarget.Process));

            return _TwillioService.ReplyWithMessageToCall("You have reached the phone of Anthony Smith. Due to the current on going Covid-19 situation. As of June 9th 2020, I no longer reside in the United Kingdom. Please email me if you wish to contact me. Thank you and stay safe.","Polly.Russell");


        }
    }
}
