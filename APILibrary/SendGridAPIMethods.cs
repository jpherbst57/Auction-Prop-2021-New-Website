using System;
using System.Collections.Generic;
using System.Text;

using SendGrid;
using System.Net.Mail;
using SendGrid.Helpers.Mail;


using System.Threading.Tasks;
using System.Configuration;

namespace APILibrary
{
    class SendGridAPIMethods
    {
    }


    public class SendGridService

    {

        private  readonly SendGridClient _client;



        public SendGridService()

        {

            // Retrieve the API key from an appSettings variable from the web.config

            //var apiKey = ConfigurationManager.AppSettings["SendGridAPIKey"];



            // Initialize the Twilio SendGrid client

           // _client = new SendGridClient(apiKey);

        }



        public async Task<Response> Send(EmailMessageInfo messageInfo)

        {

            // Prepare the Twilio SendGrid email message

            var sendgridMessage = new SendGridMessage

            {

                From = new EmailAddress(messageInfo.FromEmailAddress),

                Subject = messageInfo.EmailSubject,

                HtmlContent = messageInfo.EmailBody

            };



            // Add the "To" email address to the message

            sendgridMessage.AddTo(new EmailAddress(messageInfo.ToEmailAddress));



            // Check if any Cc email address was specified

            if (!string.IsNullOrWhiteSpace(messageInfo.CcEmailAddress))

            {

                // Add the email address for Cc to the message

                sendgridMessage.AddCc(new EmailAddress(messageInfo.CcEmailAddress));

            }



            // Check if any Bcc email address was specified

            if (!string.IsNullOrWhiteSpace(messageInfo.BccEmailAddress))

            {

                // Add the email address for Bcc to the message

                sendgridMessage.AddBcc(new EmailAddress(messageInfo.BccEmailAddress));

            }



            // Send the message to Twilio SendGrid, and save the API response

            var response = await _client.SendEmailAsync(sendgridMessage);



            // Return the Twilio SendGrid response

            return response;

        }

    }

    public class EmailMessageInfo
    {


        public string FromEmailAddress  { get; set; }



        public string ToEmailAddress { get; set; }



        public string CcEmailAddress { get; set; }



        public string BccEmailAddress { get; set; }



        public string EmailSubject { get; set; }



        public string EmailBody { get; set; }
    }
}