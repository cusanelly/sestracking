using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Amazon.SimpleEmail;
using Amazon.SimpleEmail.Model;
using ClickOpenSES.Models;

namespace ClickOpenSES.Services
{
    public interface ISesService
    {
        
    }

    public class SesService : ISesService
    {
        private static readonly string _emails = Environment.GetEnvironmentVariable("emails");
        private static readonly IAmazonSimpleEmailService _Client = new AmazonSimpleEmailServiceClient();
        public SesService()
        {

        }

        public static SendEmailRequest req { get ; set; }

        private static SetMessageModel GetMessage(ISesEvent evento) {
            SetMessageModel model = new SetMessageModel();            
            model.RecipientEmail = evento.Mail.Destination.Find(t => t.Contains(evento.Mail.Tags.Email[0]));
            
            switch (evento.EventType)
            {
                case "Click":
                    model.Subject = "User clicked email";
                    model.Body = $"User {model.RecipientEmail} has clicked link {evento.Click.Link} at {evento.Click.timestamp}";
                    model.SourceEmail = "click@legistracker.com";
                    break;
                case "Open":
                    model.Subject = "User open email";
                    model.Body = $"User {model.RecipientEmail} has opened {evento.Mail.CommonHeaders.Subject} email at {evento.Open.timestamp}";
                    model.SourceEmail = "open@legistracker.com";
                    break;
                default:
                    break;
            }
            return model;
        }

        private static SendEmailRequest SetMessage(SetMessageModel model) {            
            List<string> toemails = new List<string>();
            string[] listemails = _emails.Contains(",") ? _emails.Split(',') : new[] { _emails };
            toemails.AddRange(listemails);
            
            req = new SendEmailRequest
            {
                Source = model.SourceEmail,
                Destination = new Destination
                {
                    ToAddresses = toemails
                },
                Message = new Message
                {
                    Subject = new Content(model.Subject),
                    Body = new Body
                    {
                        Html = new Content(model.Body)
                    }
                }
            };
            return req;
        }

        public static async Task SendMessage(ISesEvent evento)
        {
            SetMessageModel model = GetMessage(evento);
            req = SetMessage(model);
            await _Client.SendEmailAsync(req);
        }
    }
}
