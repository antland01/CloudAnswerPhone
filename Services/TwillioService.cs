using System;
using Twilio.AspNet.Core;
using Twilio.Rest.Api.V2010.Account;
using Twilio.TwiML;
using Twilio;

namespace SimpleAnswerPhone
{
    public interface ITwillioService
    {

        TwiMLResult ReplyWithMessageToCall(string message, string voice);
        TwiMLResult ReplyWithMessageToSms(string message);
        public string SendSMS(string messageText, string to);
        public string SendWhatsAppMessage(string messageText, string to);
    }
    public class TwillioService : TwilioController, ITwillioService
    {

        public TwillioService()
        {
            TwilioClient.Init(Environment.GetEnvironmentVariable("TwilioSID", EnvironmentVariableTarget.Process), Environment.GetEnvironmentVariable("TwilioAuth", EnvironmentVariableTarget.Process));

        }

        public TwiMLResult ReplyWithMessageToCall(string message, string voice) => TwiML(new VoiceResponse().Say(message, voice: voice));

        public TwiMLResult ReplyWithMessageToSms(string message) => TwiML(new MessagingResponse().Message(message));


        public string SendSMS(string messageText, string to) => SendMessage(messageText, to, Environment.GetEnvironmentVariable("MyNotificationNumber", EnvironmentVariableTarget.Process));

        public string SendWhatsAppMessage(string messageText, string to) => SendMessage(messageText, "whatsapp:" + to, "whatsapp:" + Environment.GetEnvironmentVariable("MyNotificationNumber", EnvironmentVariableTarget.Process));

        private string SendMessage(string messageText, string to, string from) => MessageResource.Create(body: messageText, from: new Twilio.Types.PhoneNumber(from), to: new Twilio.Types.PhoneNumber(to), statusCallback: new Uri(Environment.GetEnvironmentVariable("FunctionURL", EnvironmentVariableTarget.Process) + "/api/APErrorCalback" + Environment.GetEnvironmentVariable("ErrorCallBackAzureFunctionKey", EnvironmentVariableTarget.Process), UriKind.Absolute)).Sid;
    }
}
